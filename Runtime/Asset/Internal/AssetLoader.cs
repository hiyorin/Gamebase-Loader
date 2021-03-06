using System.Collections.Generic;
using JetBrains.Annotations;
using UniRx.Async;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Gamebase.Loader.Asset.Internal
{
    [PublicAPI]
    internal sealed class AssetLoader : IAssetLoader, IAssetDownloader
    {
        private readonly IErrorRequester errorRequester;
        
        public AssetLoader(IErrorRequester errorRequester)
        {
            this.errorRequester = errorRequester;
        }
        
        private async UniTask Exist(object key)
        {
            var operation = Addressables.LoadResourceLocationsAsync(key);
            await operation.Task;
            if (operation.OperationException != null)
            {
                await errorRequester.Request(ErrorMessage.Create(ErrorStatus.Fatal, operation.OperationException));
                throw new InvalidKeyException(key);
            }
        }
        
        #region IAssetDownloader implementation
        
        async UniTask<long> IAssetDownloader.GetDownloadSize(IList<object> keys)
        {
            long totalSize = 0;
            
            foreach (var key in keys)
            {
                await Exist(key);
                
                var operation = Addressables.GetDownloadSizeAsync(key);
                if (!operation.IsDone)
                    await operation.Task;
                totalSize += operation.Result;
            }

            return totalSize;
        }
        
        async UniTask IAssetDownloader.Download(IList<object> keys)
        {
            var operation = Addressables.DownloadDependenciesAsync(keys);
            if (!operation.IsDone)
                await operation.Task;
        }
        
        #endregion
        
        #region IAssetLoader implementation
        
        async UniTask<AsyncOperationHandle<T>> IAssetLoader.Load<T>(object key)
        { 
            await Exist(key);

            while(true)
            {
                var operation = Addressables.LoadAssetAsync<T>(key);
                await operation.Task;
                if (operation.OperationException != null)
                {
                    var errorResult = await errorRequester.Request(ErrorMessage.Create(ErrorStatus.Fatal, operation.OperationException));
                    if (errorResult == ErrorResult.Retry)
                        continue;
                    else if (errorResult == ErrorResult.Error)
                        throw operation.OperationException;
                }
                
                return operation;
            }
        }

        void IAssetLoader.Unload(AsyncOperationHandle handle)
        {
            Addressables.Release(handle);
        }
        
        #endregion
    }
}
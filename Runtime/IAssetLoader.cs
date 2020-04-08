using System.Collections.Generic;
using UniRx.Async;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Gamebase.Loader
{
    public interface IAssetLoader
    {   
        UniTask<AsyncOperationHandle<T>> Load<T>(object key);
        
        void Unload(AsyncOperationHandle handle);
    }
}
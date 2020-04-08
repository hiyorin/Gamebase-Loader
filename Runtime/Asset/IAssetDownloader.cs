using System.Collections.Generic;
using UniRx.Async;

namespace Gamebase.Loader.Asset
{
    public interface IAssetDownloader
    {
        UniTask<long> GetDownloadSize(IList<object> keys);
        
        UniTask Download(IList<object> keys);
    }
}
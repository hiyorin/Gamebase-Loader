using UniRx.Async;

namespace Gamebase.Loader.Asset
{
    public interface IContentCatalogLoader
    {
        UniTask Load(string domain, string catalogName);
    }
}
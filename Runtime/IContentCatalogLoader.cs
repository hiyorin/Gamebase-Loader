using UniRx.Async;

namespace Gamebase.Loader
{
    public interface IContentCatalogLoader
    {
        UniTask Load(string domain, string catalogName);
    }
}
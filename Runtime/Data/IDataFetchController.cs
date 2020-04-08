using UniRx.Async;

namespace Gamebase.Loader.Data
{
    public interface IDataFetchController
    {
        UniTask Fetch();
    }
}
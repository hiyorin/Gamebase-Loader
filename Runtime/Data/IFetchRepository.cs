using UniRx.Async;

namespace Gamebase.Loader.Data
{
    public interface IFetchRepository
    {
        UniTask Fetch(string userId);
    }
}
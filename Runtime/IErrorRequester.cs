using UniRx.Async;

namespace Gamebase.Loader
{
    public interface IErrorRequester
    {
        UniTask<ErrorResult> Request(ErrorMessage errorMessage);
    }
}
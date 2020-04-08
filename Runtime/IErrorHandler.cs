using UniRx.Async;

namespace Gamebase.Loader
{
    public interface IErrorHandler
    {
        UniTask<ErrorResult> Handle(ErrorMessage message);
    }
}
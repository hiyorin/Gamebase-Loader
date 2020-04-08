using UniRx.Async;

namespace Gamebase.Loader.Data
{
    public interface IAuthController
    {
        UniTask<string> SignIn();
        
        UniTask SignOut();
    }
}
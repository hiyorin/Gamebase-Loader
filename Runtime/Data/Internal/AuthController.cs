using JetBrains.Annotations;
using UniRx.Async;

namespace Gamebase.Loader.Data.Internal
{
    [PublicAPI]
    internal sealed class AuthController : IAuthController
    {
        private readonly IAuthRepository repository;

        public AuthController(IAuthRepository repository)
        {
            this.repository = repository;
        }
        
        #region IAuthController implementation
        
        async UniTask<string> IAuthController.SignIn()
        {
            return await repository.SignIn();
        }

        async UniTask IAuthController.SignOut()
        {
            await repository.SignOut();
        }
        
        #endregion
    }
}
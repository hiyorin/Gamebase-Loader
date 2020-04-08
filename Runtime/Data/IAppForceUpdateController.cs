using System;
using UniRx;
using UniRx.Async;

namespace Gamebase.Loader.Data
{
    public interface IAppForceUpdateController
    {
        UniTask Check();
        
        IObservable<Unit> OnForceUpdateAsObservable();
    }
}
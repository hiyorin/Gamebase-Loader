using System;
using UniRx;
using UniRx.Async;

namespace Gamebase.Loader.Data
{
    public interface IAppMaintenanceController
    {
        UniTask Check();

        IObservable<Unit> OnMaintenanceAsObservable();
    }
}
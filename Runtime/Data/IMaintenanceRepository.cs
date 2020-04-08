using System;
using UniRx.Async;

namespace Gamebase.Loader.Data
{
    public interface IMaintenanceRepository
    {
        UniTask<bool> Get();
        
        IObservable<bool> OnChangeAsObservable();
    }
}
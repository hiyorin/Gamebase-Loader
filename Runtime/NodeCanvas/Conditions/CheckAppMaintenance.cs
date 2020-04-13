#if GAMEBASE_ADD_NODECANVAS
using System;
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UniRx;

namespace Gamebase.Loader.NodeCanvas.Conditions
{
    [PublicAPI]
    [Name("App Maintenance Event")]
    [Category("✫ Gamebase/Loader/Data")]
    public sealed class CheckAppMaintenance : ConditionTask<DataTaskManager>
    {
        private IDisposable disposable;

        protected override bool OnCheck()
        {
            return false;
        }
        
        protected override void OnEnable()
        {
            disposable?.Dispose();
            disposable = agent.AppMaintenance.OnMaintenanceAsObservable()
                .Subscribe(_ => YieldReturn(true));
        }

        protected override void OnDisable()
        {
            disposable?.Dispose();
            disposable = null;
        }
    }
}
#endif
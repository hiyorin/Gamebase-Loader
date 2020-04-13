#if GAMEBASE_ADD_NODECANVAS
using System;
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UniRx;

namespace Gamebase.Loader.NodeCanvas.Conditions
{
    [PublicAPI]
    [Name("Check Load Error")]
    [Category("✫ Gamebase/Loader")]
    public sealed class CheckLoaderError : ConditionTask<LoaderTaskManager>
    {
        [RequiredField] public BBParameter<ErrorStatus> status = default;
        
        private IDisposable disposable;

        protected override string info => $"Check Load Error {status}";

        protected override bool OnCheck()
        {
            return false;
        }
        
        protected override void OnEnable()
        {
            disposable?.Dispose();
            disposable = agent.ErrorReceiver.OnErrorAsObservable()
                .Where(x => x.Status == status.value)
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
#if GAMEBASE_ADD_NODECANVAS
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace Gamebase.Loader.NodeCanvas.Actions
{
    [PublicAPI]
    [Name("SignIn")]
    [Category("✫ Gamebase/Loader")]
    public sealed class SignIn : ActionTask<DataTaskManager>
    {
        [BlackboardOnly] public BBParameter<string> userId = default;
        
        protected override void OnExecute()
        {
            var task = agent.Auth.SignIn().GetAwaiter();
            task.OnCompleted(() =>
            {
                userId.value = task.GetResult();
                EndAction(true);
            });
        }
    }
}
#endif
#if GAMEBASE_ADD_NODECANVAS
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace Gamebase.Loader.NodeCanvas.Actions
{
    [PublicAPI]
    [Name("Validate Data")]
    [Category("✫ Gamebase/Loader/Data")]
    public sealed class ValidateData : ActionTask<DataTaskManager>
    {
        protected override void OnExecute()
        {
            agent.DataValidate.Validate();
            EndAction(true);
        }
    }
}
#endif
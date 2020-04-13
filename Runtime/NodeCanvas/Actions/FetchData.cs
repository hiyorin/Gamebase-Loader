#if GAMEBASE_ADD_NODECANVAS
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace Gamebase.Loader.NodeCanvas.Actions
{
    [PublicAPI]
    [Name("Fetch Data")]
    [Category("✫ Gamebase/Loader/Data")]
    public sealed class FetchData : ActionTask<DataTaskManager>
    {
        protected override void OnExecute()
        {
            agent.DataFetch.Fetch().GetAwaiter().OnCompleted(() => EndAction(true));
        }
    }
}
#endif
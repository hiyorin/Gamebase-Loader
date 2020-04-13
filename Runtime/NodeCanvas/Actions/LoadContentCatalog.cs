#if GAMEBASE_ADD_NODECANVAS
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace Gamebase.Loader.NodeCanvas.Actions
{
    [PublicAPI]
    [Name("Load Content Catalog")]
    [Category("✫ Gamebase/Loader/Asset")]
    public sealed class LoadContentCatalog : ActionTask<LoaderTaskManager>
    {
        [RequiredField] public BBParameter<string> domain;

        [RequiredField] public BBParameter<string> catalogName;

        protected override void OnExecute()
        {
            agent.ContentCatalogLoader.Load(domain.value, catalogName.value)
                .GetAwaiter()
                .OnCompleted(EndAction);
        }
    }
}
#endif
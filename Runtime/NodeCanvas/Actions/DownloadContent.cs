#if GAMEBASE_ADD_NODECANVAS
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace Gamebase.Loader.NodeCanvas.Actions
{
    [PublicAPI]
    [Name("Download Content")]
    [Category("✫ Gamebase/Loader/Asset")]
    public sealed class DownloadContent : ActionTask<LoaderTaskManager>
    {
        [RequiredField] public BBParameter<List<string>> keys;

        protected override string info => $"{base.info} ({keys})";

        protected override void OnExecute()
        {
            agent.AssetDownloader.Download(keys.value.Cast<object>().ToList())
                .GetAwaiter()
                .OnCompleted(EndAction);
        }
    }
}
#endif
#if GAMEBASE_ADD_NODECANVAS
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace Gamebase.Loader.NodeCanvas.Actions
{
    [PublicAPI]
    [Name("Get Download Content Size")]
    [Category("✫ Gamebase/Loader/Asset")]
    public sealed class GetDownloadContentSize : ActionTask<LoaderTaskManager>
    {
        [RequiredField] public BBParameter<List<string>> keys;

        [BlackboardOnly] public BBParameter<long> downloadSize;

        protected override string info => $"{downloadSize} = {base.info}";

        protected override void OnExecute()
        {
            var awaiter = agent.AssetDownloader.GetDownloadSize(keys.value.Cast<object>().ToList()).GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                downloadSize.value = awaiter.GetResult();
                EndAction();
            });
        }
    }
}
#endif
#if GAMEBASE_ADD_NODECANVAS
using Gamebase.Loader.Asset;
using UnityEngine;
using Zenject;

namespace Gamebase.Loader.NodeCanvas
{
    public sealed class LoaderTaskManager : MonoBehaviour
    {
        [Inject] internal IAssetLoader AssetLoader { get; } = default;

        [Inject] internal IAssetDownloader AssetDownloader { get; } = default;

        [Inject] internal IContentCatalogLoader ContentCatalogLoader { get; } = default;

        [Inject] internal IErrorRequester ErrorRequester { get; } = default;
        
        [Inject] internal IErrorReceiver ErrorReceiver { get; } = default;
    }
}
#endif
#if GAMEBASE_ADD_NODECANVAS
using Gamebase.Loader.Data;
using UnityEngine;
using Zenject;

namespace Gamebase.Loader.NodeCanvas
{
    public sealed class DataTaskManager : MonoBehaviour
    {
        [Inject] internal IAuthController Auth { get; } = default;
            
        [Inject] internal IDataFetchController DataFetch { get; } = default;

        [Inject] internal IDataValidateController DataValidate { get; } = default;

        [Inject] internal IAppForceUpdateController AppForceUpdate { get; }= default;

        [Inject] internal IAppMaintenanceController AppMaintenance { get; }= default;
    }
}
#endif
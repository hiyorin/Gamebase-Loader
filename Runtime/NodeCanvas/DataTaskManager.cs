#if GAMEBASE_ADD_NODECANVAS
using Gamebase.Loader.Data;
using UnityEngine;
using Zenject;

namespace Gamebase.Loader.NodeCanvas
{
    public sealed class DataTaskManager : MonoBehaviour
    {
        [Inject] private IAuthController auth = default;
            
        [Inject] private IDataFetchController dataFetch = default;

        [Inject] private IDataValidateController dataValidate = default;

        [Inject] private IAppForceUpdateController appForceUpdate = default;

        [Inject] private IAppMaintenanceController appMaintenance = default;
        
        internal IAuthController Auth => auth;
        
        internal IDataFetchController DataFetch => dataFetch;

        internal IDataValidateController DataValidate => dataValidate;

        internal IAppForceUpdateController AppForceUpdate => appForceUpdate;

        internal IAppMaintenanceController AppMaintenance => appMaintenance;
    }
}
#endif
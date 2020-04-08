using Gamebase.Loader.Asset.Internal;
using Gamebase.Loader.Data.Internal;
using Gamebase.Loader.Internal;
using UnityEngine;
using Zenject;

namespace Gamebase.Loader
{
    [CreateAssetMenu(fileName = "LoaderInstaller", menuName = "Installers/Gamebase/LoaderInstaller")]
    public sealed class LoaderInstaller : ScriptableObjectInstaller<LoaderInstaller>
    {
        [SerializeField] private NetworkSettings networkSettings = default;
        
        public override void InstallBindings()
        {
            var subContainer = Container.CreateSubContainer();
            InstallSubContainer(subContainer);
            
            AssetLoaderInstaller.BindInterface(Container, subContainer);
            DataLoaderInstaller.BindInterface(Container, subContainer);
            
            Container.BindInterfacesTo<WebRequester>()
                .FromSubContainerResolve()
                .ByInstance(subContainer)
                .AsSingle();

            Container.BindInterfacesTo<ErrorManager>()
                .FromSubContainerResolve()
                .ByInstance(subContainer)
                .AsSingle();
        }

        private void InstallSubContainer(DiContainer subContainer)
        {
            subContainer.Install<AssetLoaderInstaller>();
            subContainer.Install<DataLoaderInstaller>();
            
            subContainer.Bind<WebRequester>().AsSingle();
            subContainer.Bind<ErrorManager>().AsSingle();

            subContainer.BindInstance(networkSettings).AsSingle();
        }
    }
}
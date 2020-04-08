using JetBrains.Annotations;
using Zenject;

namespace Gamebase.Loader.Asset.Internal
{
    [PublicAPI]
    internal sealed class AssetLoaderInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<AssetLoader>().AsSingle();
            Container.Bind<ContentCatalogLoader>().AsSingle();
        }

        public static void BindInterface(DiContainer container, DiContainer subContainer)
        {
            container.BindInterfacesTo<AssetLoader>()
                .FromSubContainerResolve()
                .ByInstance(subContainer)
                .AsSingle();

            container.BindInterfacesTo<ContentCatalogLoader>()
                .FromSubContainerResolve()
                .ByInstance(subContainer)
                .AsSingle();
        }
    }
}
using CustomSaberColors.UI;
using CustomSaberColors.UI.Views;
using Zenject;

namespace CustomSaberColors.Installers;

internal class MenuInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<MainViewController>().FromNewComponentAsViewController().AsSingle();
        Container.Bind<MenuFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
        Container.BindInterfacesTo<MenuButtonManager>().AsSingle();
    }
}

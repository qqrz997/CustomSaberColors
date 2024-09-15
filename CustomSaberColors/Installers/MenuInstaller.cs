using BeatSaberMarkupLanguage.Tags;
using CustomSaberColors.Menu;
using CustomSaberColors.Menu.CustomTags;
using CustomSaberColors.Menu.Views;
using Zenject;

namespace CustomSaberColors.Installers;

internal class MenuInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<MainViewController>().FromNewComponentAsViewController().AsSingle();
        Container.Bind<MenuFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
        Container.BindInterfacesTo<MenuButtonManager>().AsSingle();

        Container.Bind<BSMLTag>().To<SaberColorEditorTag>().AsSingle();
    }
}

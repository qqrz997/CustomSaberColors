using CustomSaberColors.Game;
using Zenject;

namespace CustomSaberColors.Installers;

internal class PlayerInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SiraSaberFetcher>().AsSingle();
        Container.BindInterfacesTo<SaberColorProcessor>().AsSingle();
        Container.BindInterfacesTo<SaberColorer>().AsSingle();
    }
}

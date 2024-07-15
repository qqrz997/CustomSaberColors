using CustomSaberColors.Game;
using Zenject;

namespace CustomSaberColors.Installers;

internal class PlayerInstaller : Installer
{
    public override void InstallBindings()
    {
        if (!Container.Resolve<PluginConfig>().Enabled)
        {
            return;
        }

        Container.BindInterfacesAndSelfTo<SiraSaberFetcher>().AsSingle();
        Container.BindInterfacesTo<SaberColorProcessor>().AsSingle();
        Container.BindInterfacesTo<SaberColorer>().AsSingle();
    }
}

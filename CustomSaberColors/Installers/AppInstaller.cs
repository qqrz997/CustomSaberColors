using CustomSaberColors.Project;
using Zenject;

namespace CustomSaberColors.Installers;

internal class AppInstaller(PluginConfig config) : Installer
{
    private readonly PluginConfig config = config;

    public override void InstallBindings()
    {
        Container.BindInstance(config);
    }
}

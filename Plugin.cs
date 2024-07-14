using CustomSaberColors.Installers;
using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Logging;
using SiraUtil.Zenject;
using System.Reflection;

namespace CustomSaberColors;

[Plugin(RuntimeOptions.SingleStartInit), NoEnableDisable]
public class Plugin
{
    private Harmony harmony = new("CustomSaberColors");

    [Init]
    public Plugin(Logger logger, Config config, Zenjector zenjector)
    {
        var pluginConfig = config.Generated<PluginConfig>();
        zenjector.UseLogger(logger);
        zenjector.Install<AppInstaller>(Location.App, pluginConfig);
        zenjector.Install<MenuInstaller>(Location.Menu);
        zenjector.Install<PlayerInstaller>(Location.Player);
    }
}

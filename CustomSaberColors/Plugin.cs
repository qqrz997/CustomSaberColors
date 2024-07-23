using BeatSaberMarkupLanguage;
using CustomSaberColors.Installers;
using CustomSaberColors.Menu.CustomTags;
using CustomSaberColors.Project;
using IPA;
using IPA.Config.Stores;
using IPA.Logging;
using SiraUtil.Zenject;

using Config = IPA.Config.Config;

namespace CustomSaberColors;

[Plugin(RuntimeOptions.SingleStartInit), NoEnableDisable]
internal class Plugin
{
    // Reader's note:
    // As someone who has spelled it as "colour" their entire life,
    // writing this plugin has been a mental nightmare.
    [Init]
    public Plugin(Logger logger, Config config, Zenjector zenjector)
    {
        var pluginConfig = config.Generated<PluginConfig>();
        zenjector.UseLogger(logger);
        zenjector.Install<AppInstaller>(Location.App, pluginConfig);
        zenjector.Install<MenuInstaller>(Location.Menu);
        zenjector.Install<PlayerInstaller>(Location.Player);

        BSMLParser.instance.RegisterTag(new SaberColorEditorTag());
    }
}

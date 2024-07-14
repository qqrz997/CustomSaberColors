using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using SiraUtil.Logging;
using UnityEngine;
using Zenject;

namespace CustomSaberColors.UI.Views
{
    [HotReload(RelativePathToLayout = "../BSML/main.bsml")]
    [ViewDefinition("CustomSaberColors.UI.BSML.main.bsml")]
    internal class MainViewController : BSMLAutomaticViewController
    {
        private PluginConfig config;
        private SiraLog log;

        [Inject]
        private void Construct(PluginConfig config, SiraLog log)
        {
            this.config = config;
            this.log = log;
        }

        [UIValue("mod-enabled")]
        public bool Enabled
        {
            get => config.Enabled;
            set => config.Enabled = value;
        }

        [UIValue("left-color")]
        public Color LeftColor
        {
            get => config.CurrentLeftColor;
            set => config.CurrentLeftColor = value;
        }

        [UIValue("right-color")]
        public Color RightColor
        {
            get => config.CurrentRightColor;
            set => config.CurrentRightColor = value;
        }
    }
}

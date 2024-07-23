using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using CustomSaberColors.Menu.CustomTags;
using CustomSaberColors.Project;
using HMUI;
using System.Linq;
using UnityEngine;
using Zenject;

namespace CustomSaberColors.Menu.Views;

[HotReload(RelativePathToLayout = "../BSML/main.bsml")]
[ViewDefinition("CustomSaberColors.Menu.BSML.main.bsml")]
internal class MainViewController : BSMLAutomaticViewController
{
    [Inject] private readonly PluginConfig config;

    [UIComponent("color-editor")]
    private SaberColorEditorController colorEditor;

    [UIValue("mod-enabled")]
    public bool Enabled
    {
        get => config.Enabled;
        set => config.Enabled = value;
    }

    [UIAction("#post-parse")]
    private void PostPare()
    {
        colorEditor.ToggleGroup.SetColors(config.CurrentLeftColor, config.CurrentRightColor);
        colorEditor.Color = colorEditor.ToggleGroup.Color;
        colorEditor.ToggleGroup.SelectedColorChanged += OnToggleGroupColorChanged;
        colorEditor.RgbController.colorDidChangeEvent += OnRGBPanelColorChanged;
        colorEditor.HsvController.colorDidChangeEvent += OnHSVPanelColorChanged;
    }

    private void OnToggleGroupColorChanged(Color color)
    {
        colorEditor.RgbController.color = color;
        colorEditor.HsvController.color = color;
    }

    private void OnRGBPanelColorChanged(Color color, ColorChangeUIEventType eventType)
    {
        colorEditor.ToggleGroup.Color = color;
        colorEditor.HsvController.color = color;

        if (eventType == ColorChangeUIEventType.PointerUp)
        {
            (config.CurrentLeftColor, config.CurrentRightColor) = colorEditor.ToggleGroup.EditedColors;
        }
    }

    private void OnHSVPanelColorChanged(Color color, ColorChangeUIEventType eventType)
    {
        colorEditor.ToggleGroup.Color = color;
        colorEditor.RgbController.color = color;

        if (eventType == ColorChangeUIEventType.PointerUp)
        {
            (config.CurrentLeftColor, config.CurrentRightColor) = colorEditor.ToggleGroup.EditedColors;
        }
    }

    protected override void OnDestroy()
    {
        if (colorEditor)
        {
            colorEditor.ToggleGroup.SelectedColorChanged -= OnToggleGroupColorChanged;
            colorEditor.RgbController.colorDidChangeEvent -= OnHSVPanelColorChanged;
            colorEditor.HsvController.colorDidChangeEvent -= OnHSVPanelColorChanged;
        }

        base.OnDestroy();
    }
}

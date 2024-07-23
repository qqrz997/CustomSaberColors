using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using CustomSaberColors.Menu.CustomTags;
using CustomSaberColors.Project;
using UnityEngine;
using Zenject;

namespace CustomSaberColors.Menu.Views;

[HotReload(RelativePathToLayout = "../BSML/main.bsml")]
[ViewDefinition("CustomSaberColors.Menu.BSML.main.bsml")]
internal class MainViewController : BSMLAutomaticViewController
{
    [Inject] private readonly PluginConfig config;

    [UIComponent("color-editor")]
    private readonly SaberColorEditorController colorEditor;

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
        colorEditor.RgbPanel.color = colorEditor.ToggleGroup.Color;
        colorEditor.HsvPanel.color = colorEditor.ToggleGroup.Color;
        colorEditor.PreviousColorPanel.AddColor(colorEditor.ToggleGroup.Color);
        colorEditor.ToggleGroup.SelectedColorChanged += OnToggleGroupColorChanged;
        colorEditor.RgbPanel.colorDidChangeEvent += OnRGBPanelColorChanged;
        colorEditor.HsvPanel.colorDidChangeEvent += OnHSVPanelColorChanged;
        colorEditor.PreviousColorPanel.colorWasSelectedEvent += OnPreviousColorSelected;
    }

    private void OnToggleGroupColorChanged(Color color)
    {
        colorEditor.RgbPanel.color = color;
        colorEditor.HsvPanel.color = color;
        colorEditor.PreviousColorPanel.AddColor(color);
    }

    private void OnRGBPanelColorChanged(Color color, ColorChangeUIEventType eventType)
    {
        colorEditor.ToggleGroup.Color = color;
        colorEditor.HsvPanel.color = color;

        if (eventType == ColorChangeUIEventType.PointerUp)
        {
            colorEditor.PreviousColorPanel.AddColor(color);
            (config.CurrentLeftColor, config.CurrentRightColor) = colorEditor.ToggleGroup.EditedColors;
        }
    }

    private void OnHSVPanelColorChanged(Color color, ColorChangeUIEventType eventType)
    {
        colorEditor.ToggleGroup.Color = color;
        colorEditor.RgbPanel.color = color;

        if (eventType == ColorChangeUIEventType.PointerUp)
        {
            colorEditor.PreviousColorPanel.AddColor(color);
            (config.CurrentLeftColor, config.CurrentRightColor) = colorEditor.ToggleGroup.EditedColors;
        }
    }

    private void OnPreviousColorSelected(Color color)
    {
        colorEditor.ToggleGroup.Color = color;
        colorEditor.RgbPanel.color = color;
        colorEditor.HsvPanel.color = color;
        (config.CurrentLeftColor, config.CurrentRightColor) = colorEditor.ToggleGroup.EditedColors;
    }

    protected override void OnDestroy()
    {
        if (colorEditor)
        {
            colorEditor.ToggleGroup.SelectedColorChanged -= OnToggleGroupColorChanged;
            colorEditor.RgbPanel.colorDidChangeEvent -= OnRGBPanelColorChanged;
            colorEditor.HsvPanel.colorDidChangeEvent -= OnHSVPanelColorChanged;
            colorEditor.PreviousColorPanel.colorWasSelectedEvent -= OnPreviousColorSelected;
        }

        base.OnDestroy();
    }
}

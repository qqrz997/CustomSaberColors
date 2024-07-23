using BeatSaberMarkupLanguage.Parser;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace CustomSaberColors.Menu.CustomTags;

internal class SaberColorEditorController : MonoBehaviour
{
    public SaberColorsToggleGroup ToggleGroup { get; private set; }

    public RGBPanelController RgbPanel { get; private set; }

    public HSVPanelController HsvPanel { get; private set; }

    public PreviousColorPanelController PreviousColorPanel { get; private set; }

    public void Init(RGBPanelController rgbPanel, HSVPanelController hsvPanel, SaberColorsToggleGroup toggleGroup, PreviousColorPanelController previousColorPanel)
    {
        RgbPanel = rgbPanel;
        HsvPanel = hsvPanel;
        ToggleGroup = toggleGroup;
        PreviousColorPanel = previousColorPanel;
    }
}

using BeatSaberMarkupLanguage.Parser;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace CustomSaberColors.Menu.CustomTags;

internal class SaberColorEditorController : MonoBehaviour
{
    private Image previousColorImage;

    public BSMLValue Value { private get; set; }

    private Color color;

    public Color Color
    {
        get => color;
        set
        {
            color = value;

            if (RgbController)
            {
                RgbController.color = value;
            }

            if (HsvController && HsvController.color != value)
            {
                HsvController.color = value;
            }

            if (previousColorImage)
            {
                previousColorImage.color = value;
            }
        }
    }

    public SaberColorsToggleGroup ToggleGroup { get; private set; }

    public RGBPanelController RgbController { get; private set; }

    public HSVPanelController HsvController { get; private set; }

    public Action<Color> ColorChanged;

    public void Init(RGBPanelController rgbController, HSVPanelController hsvController, SaberColorsToggleGroup toggleGroup)
    {
        RgbController = rgbController;
        HsvController = hsvController;
        ToggleGroup = toggleGroup;
    }

    public void OnChange(Color color, ColorChangeUIEventType type)
    {
        ColorChanged?.Invoke(color);
        Color = color;
    }

    private void Awake()
    {

    }

    private void Start()
    {
        if (Value != null)
        {
            Color = (Color)Value.GetValue();
        }
    }
}

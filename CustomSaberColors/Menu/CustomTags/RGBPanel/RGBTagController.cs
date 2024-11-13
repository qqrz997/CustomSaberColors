using BeatSaberMarkupLanguage.Parser;
using HMUI;
using System;
using UnityEngine;

namespace CustomSaberColors.Menu.CustomTags.RGBPanel;

/*internal class RGBTagController : MonoBehaviour
{
    private RGBPanelController rgbController;
    private Color color;

    public bool DisableSkew { get; set; }

    public BSMLValue Value { private get; set; }

    public Color Color
    {
        get => color;
        set
        {
            color = value;

            if (rgbController)
            {
                rgbController.color = value;
            }
        }
    }

    public Action<Color> ColorChanged;

    public void Init(RGBPanelController rgbController) =>
        this.rgbController = rgbController;

    public void OnChange(Color color, ColorChangeUIEventType type)
    {
        ColorChanged?.Invoke(color);
        Color = color;
    }

    private void Start()
    {
        if (Value != null)
        {
            Color = (Color)Value.GetValue();
        }

        var r = rgbController.transform.Find("Content/RGradientSlider") as RectTransform;
        var g = rgbController.transform.Find("Content/GGradientSlider") as RectTransform;
        var b = rgbController.transform.Find("Content/BGradientSlider") as RectTransform;
        r.sizeDelta = b.sizeDelta;
        g.sizeDelta = b.sizeDelta;

        if (DisableSkew)
        {
            foreach (var image in rgbController.GetComponentsInChildren<ImageView>())
                image._skew = 0f;
            g.offsetMin = g.offsetMin with { x = r.offsetMin.x };
            g.offsetMax = g.offsetMax with { x = r.offsetMax.x };
            b.offsetMin = b.offsetMin with { x = r.offsetMin.x };
            b.offsetMax = b.offsetMax with { x = r.offsetMax.x };
        }

    }
}*/

using BeatSaberMarkupLanguage.Tags;
using CustomSaberColors.Utilities.Extensions;
using HMUI;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace CustomSaberColors.Menu.CustomTags;

/// <summary>
/// TODO:
/// This is a complete mess, if you try to use this tag in any other way it completely breaks.
/// The different components need to be anchored properly.
/// </summary>
internal class SaberColorEditorTag : BSMLTag
{
    public override string[] Aliases => ["color-editor"];

    public override GameObject CreateObject(Transform parent)
    {
        var gameObject = new GameObject("SaberColorEditorController") { layer = 5 };
        var controller = gameObject.AddComponent<SaberColorEditorController>();
        var transform = gameObject.AddComponent<RectTransform>();
        transform.SetParent(parent, false);

        transform.sizeDelta = new(135f, 70f);
        transform.anchorMin = new(0.5f, 0.5f);
        transform.anchorMax = transform.anchorMin;

        var gameplaySetup = DiContainer.Resolve<GameplaySetupViewController>();

        var editColorSchemeController = gameplaySetup.GetComponentInChildren<EditColorSchemeController>(true);
        var rgbTemplate = editColorSchemeController.GetComponentInChildren<RGBPanelController>();
        var hsvTemplate = editColorSchemeController.GetComponentInChildren<HSVPanelController>();
        var toggleTemplate = editColorSchemeController.GetComponentInChildren<ColorSchemeColorToggleController>();

        var rgbController = Object.Instantiate(rgbTemplate, gameObject.transform, false);
        rgbController.name = "RGBPanel";
        var rgbTransform = rgbController.transform as RectTransform;
        rgbTransform.anchoredPosition = new(0f, 1f);
        rgbTransform.anchorMin = new(0f, 0.25f);
        rgbTransform.anchorMax = rgbTransform.anchorMin;
        rgbTransform.offsetMin = new(15f, 0f);
        rgbTransform.offsetMax = new(61f, 52f);

        var b = rgbController.transform.Find("Content/BGradientSlider") as RectTransform;
        ((RectTransform)rgbController.transform.Find("Content/RGradientSlider")).sizeDelta = b.sizeDelta;
        ((RectTransform)rgbController.transform.Find("Content/GGradientSlider")).sizeDelta = b.sizeDelta;

        var hsvController = Object.Instantiate(hsvTemplate, gameObject.transform, false);
        hsvController.name = "HSVPanel";
        var hsvTransform = hsvController.transform as RectTransform;
        hsvTransform.anchoredPosition = new(0, 3);
        hsvTransform.anchorMin = new(0.5f, 0.15f);
        hsvTransform.anchorMax = hsvTransform.anchorMin;
        hsvTransform.offsetMin = new(8f, 3f);
        hsvTransform.offsetMax = new(62f, 57f);

        var toggleGroupObject = new GameObject("SaberColorsToggleGroup") { layer = 5 };
        toggleGroupObject.transform.SetParent(transform, false);
        var saberColorsToggleGroup = toggleGroupObject.AddComponent<SaberColorsToggleGroup>();
        var toggleGroup = toggleGroupObject.AddComponent<ToggleGroup>();
        var toggleGroupTransform = toggleGroupObject.AddComponent<RectTransform>();
        var toggleGroupHorizontal = toggleGroupObject.AddComponent<HorizontalLayoutGroup>();
        
        toggleGroupTransform.Reset();
        toggleGroupTransform.sizeDelta = new(-115.5f, -84f);
        toggleGroupHorizontal.childControlWidth = false;
        toggleGroupHorizontal.childControlHeight = false;
        toggleGroupHorizontal.childForceExpandWidth = false;
        toggleGroupHorizontal.childForceExpandHeight = false;
        toggleGroupHorizontal.spacing = -1.68f;

        var saberAColorToggleController = Object.Instantiate(toggleTemplate, toggleGroupObject.transform, false);
        var saberBColorToggleController = Object.Instantiate(toggleTemplate, toggleGroupObject.transform, false);
        saberAColorToggleController.name = "SaberA";
        saberBColorToggleController.name = "SaberB";
        saberAColorToggleController.toggle.group = toggleGroup;
        saberBColorToggleController.toggle.group = toggleGroup;
        var handSprite = GameObject.FindObjectsOfType<ImageView>(true).First(image => image.sprite.name == "LeftHandedIcon").sprite;
        var saberAIcon = saberAColorToggleController.transform.Find("Icon").GetComponent<ImageView>();
        saberAIcon.sprite = handSprite;
        saberAIcon._skew *= -1.0f;
        saberAIcon.transform.rotation = Quaternion.Euler(0, 180, 0);
        saberBColorToggleController.transform.Find("Icon").GetComponent<ImageView>().sprite = handSprite;

        saberColorsToggleGroup.Init(saberAColorToggleController, saberBColorToggleController);
        controller.Init(rgbController, hsvController, saberColorsToggleGroup);
        rgbController.colorDidChangeEvent += controller.OnChange;
        hsvController.colorDidChangeEvent += controller.OnChange;

        gameObject.SetActive(true);

        return gameObject;
    }
}

using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.Tags;
using UnityEngine;
using UnityEngine.UI;

namespace CustomSaberColors.Menu.CustomTags.RGBPanel;

/// <summary>
/// TODO:
/// Separating the color editor components will make customizability better.
/// This tag is currently not in use.
/// </summary>
/*internal class RGBPanelTag : BSMLTag
{
    public override string[] Aliases => ["rgb-panel"];

    public override GameObject CreateObject(Transform parent)
    {
        // TODO WIP
        var gameObject = new GameObject("CustomRGBPanel") { layer = 5 };
        gameObject.transform.SetParent(parent, false);
        var rgbOriginal = DiContainer
            .Resolve<GameplaySetupViewController>()
            .GetComponentInChildren<EditColorSchemeController>(true)
            .GetComponentInChildren<RGBPanelController>();
        var rgbController = Object.Instantiate(rgbOriginal, gameObject.transform, false);
        rgbController.gameObject.name = "SaberColorsRGBPanel";

        var controller = gameObject.AddComponent<RGBTagController>();
        controller.Init(rgbController);
        rgbController.colorDidChangeEvent += controller.OnChange;

        // this doesn't do anything (anchor controlled by parent?)
        var transform = gameObject.AddComponent<RectTransform>();
        //transform.anchorMin = new Vector2(0.0f, 1.0f);
        //transform.anchorMax = new Vector2(1.0f, 0.0f);

        var rgbControllerTransform = rgbController.transform as RectTransform;
        rgbControllerTransform.offsetMin = Vector2.zero;
        rgbControllerTransform.offsetMax = Vector2.zero;
        rgbControllerTransform.anchorMin = new Vector2(0, 1);
        rgbControllerTransform.anchorMax = new Vector2(0, 1);

        var contentTransform = rgbControllerTransform.Find("Content") as RectTransform;
        contentTransform.offsetMin = Vector2.zero;
        contentTransform.offsetMax = Vector2.zero;

        var layoutElement = gameObject.AddComponent<LayoutElement>();

        gameObject.AddComponent<Backgroundable>();
        gameObject.AddComponent<ContentSizeFitter>();
        return gameObject;
    }
}*/

using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.TypeHandlers;
using System;
using System.Collections.Generic;

namespace CustomSaberColors.Menu.CustomTags.RGBPanel;

[ComponentHandler(typeof(RGBTagController))]
internal class RGBPanelHandler : TypeHandler<RGBTagController>
{
    public override Dictionary<string, Action<RGBTagController, string>> Setters => new()
    {
        { "disable-skew", (tagController, propertyText) => tagController.DisableSkew = bool.Parse(propertyText) }
    };

    public override Dictionary<string, string[]> Props => new()
    {
        { "value", ["value"] },
        { "disable-skew", ["disable-skew"] }
    };
}

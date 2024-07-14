using IPA.Config.Stores;
using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace CustomSaberColors;

internal class PluginConfig
{
    public Color CurrentLeftColor { get; set; } = new(0.784f, 0.078f, 0.078f);

    public Color CurrentRightColor { get; set; } = new(0.157f, 0.557f, 0.824f);
}

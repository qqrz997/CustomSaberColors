using IPA.Config.Stores;
using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace CustomSaberColors.Project;

internal class PluginConfig
{
    public virtual bool Enabled { get; set; } = true;

    public virtual Color CurrentLeftColor { get; set; } = new(0.784f, 0.078f, 0.078f);

    public virtual Color CurrentRightColor { get; set; } = new(0.157f, 0.557f, 0.824f);
}

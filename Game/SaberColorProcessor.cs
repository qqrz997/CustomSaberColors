using SiraUtil.Sabers;
using System.Collections.Generic;
using UnityEngine;

namespace CustomSaberColors.Game;

internal class SaberColorProcessor : ISaberColorProcessor
{
    private readonly SaberManager saberManager;
    private readonly SiraSaberFetcher saberFetcher;
    private readonly SaberModelManager saberModelManager;

    private SaberColorProcessor(SaberManager saberManager, SiraSaberFetcher saberFetcher, SaberModelManager saberModelManager)
    {
        this.saberManager = saberManager;
        this.saberFetcher = saberFetcher;
        this.saberModelManager = saberModelManager;
    }

    private Saber LeftSaber => saberManager.leftSaber;

    private Saber RightSaber => saberManager.rightSaber;

    private List<SiraSaber> SpawnedSabers => saberFetcher.SpawnedSabers;

    public void SetSaberColors(Color left, Color right)
    {
        saberModelManager.SetColor(LeftSaber, left);
        saberModelManager.SetColor(RightSaber, right);

        foreach (var saber in SpawnedSabers)
        {
            var color = saber.Saber.saberType == SaberType.SaberA ? left : right;
            saber.SetColor(color);
        }
    }
}

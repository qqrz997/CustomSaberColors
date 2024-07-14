using IPA.Utilities.Async;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CustomSaberColors.Game;

internal class SaberColorer : IInitializable
{
    private readonly PluginConfig config;
    private readonly ICoroutineStarter coroutineStarter;
    private readonly ISaberColorProcessor colorProcessor;

    private SaberColorer(PluginConfig config, ICoroutineStarter coroutineStarter, ISaberColorProcessor colorProcessor)
    {
        this.config = config;
        this.coroutineStarter = coroutineStarter;
        this.colorProcessor = colorProcessor;
    }

    public void Initialize() => 
        coroutineStarter.StartCoroutine(WaitForSaberModelController());

    private IEnumerator WaitForSaberModelController()
    {
        yield return new WaitUntil(() => Resources.FindObjectsOfTypeAll<SaberModelController>().Any());
        UnityMainThreadTaskScheduler.Factory.StartNew(ApplyColors);
    }

    private async Task ApplyColors()
    {
        var attempts = 3;
        var interval = 600;

        while (attempts-- > 0)
        {
            colorProcessor.SetSaberColors(config.CurrentLeftColor, config.CurrentRightColor);
            await Task.Delay(interval);
        }
    }
}

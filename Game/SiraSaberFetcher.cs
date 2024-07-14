using SiraUtil.Affinity;
using SiraUtil.Sabers;
using System;
using System.Collections.Generic;

namespace CustomSaberColors.Game
{
    internal class SiraSaberFetcher : IDisposable
    {
        private readonly SiraSaberFactory factory;

        private SiraSaberFetcher(SiraSaberFactory factory)
        {
            this.factory = factory;
            this.factory.SaberCreated += OnSaberCreated;
        }

        private readonly List<SiraSaber> spawnedSabers = [];

        public List<SiraSaber> SpawnedSabers => spawnedSabers;

        public void Dispose() => 
            factory.SaberCreated -= OnSaberCreated;

        private void OnSaberCreated(SiraSaber saberRef) => 
            spawnedSabers.Add(saberRef);
    }
}

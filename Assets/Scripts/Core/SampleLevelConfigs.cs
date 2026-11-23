using UnityEngine;
using System.Collections.Generic;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Core
{
    /// <summary>
    /// Generates a full set of sample LevelConfigs at runtime so you can test progression immediately.
    /// Attach to the same object as LevelManager or call from FirstLaunchManager.
    /// </summary>
    public class SampleLevelConfigs : MonoBehaviour
    {
        public void GenerateSampleLevels()
        {
            var levelManager = FindObjectOfType<LevelManager>();
            if (levelManager == null) return;

            levelManager.levels.Clear();

            levelManager.levels.Add(Create("River Oil Spill", PollutionType.OilSpill, 600, 100f, "A tanker accident has coated the river. Deploy skimmers before the oil spreads further."));
            levelManager.levels.Add(Create("City Air Crisis", PollutionType.Air, 550, 100f, "Industrial emissions have made the air hazardous. Install scrubbers across the zone."));
            levelManager.levels.Add(Create("Coastal Water Contamination", PollutionType.Water, 500, 100f, "Runoff is poisoning the bay. Filter the water before the ecosystem collapses."));
            levelManager.levels.Add(Create("Old Landfill", PollutionType.SolidWaste, 650, 100f, "A neglected landfill is leaching toxins. Cap and collect gases to stabilize it."));
            levelManager.levels.Add(Create("Aquifer Threat", PollutionType.Groundwater, 700, 100f, "Chemicals are seeping into the groundwater. Extract and treat before wells are lost."));
            levelManager.levels.Add(Create("Highway Noise Zone", PollutionType.Noise, 450, 100f, "Constant traffic noise is damaging the nearby forest. Install barriers to restore quiet."));

            Debug.Log($"Generated {levelManager.levels.Count} sample levels");
            levelManager.LoadLevel(0);
        }

        private LevelConfig Create(string name, PollutionType type, int budget, float contamination, string briefing)
        {
            var config = ScriptableObject.CreateInstance<LevelConfig>();
            config.levelName = name;
            config.pollutionType = type;
            config.startingBudget = budget;
            config.startingContamination = contamination;
            config.briefing = briefing;
            return config;
        }
    }
}

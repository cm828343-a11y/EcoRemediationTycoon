using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Core
{
    /// <summary>
    /// Generates sample levels with progressive difficulty.
    /// First two are simple (lower contamination + higher budget).
    /// Later levels have higher contamination (longer remediation) and tighter budgets.
    /// </summary>
    public class SampleLevelConfigs : MonoBehaviour
    {
        public void GenerateSampleLevels()
        {
            var levelManager = FindObjectOfType<LevelManager>();
            if (levelManager == null) return;

            levelManager.levels.Clear();

            // Level 1 & 2 - Simple / short
            levelManager.levels.Add(Create("Small Creek Spill", PollutionType.OilSpill, 800, 60f, "A minor spill in a small creek. Easy cleanup to learn the basics."));
            levelManager.levels.Add(Create("Factory Air Leak", PollutionType.Air, 750, 65f, "A localized air problem. Place a few scrubbers and finish quickly."));

            // Level 3+ - Increasing difficulty and length
            levelManager.levels.Add(Create("Coastal Water Contamination", PollutionType.Water, 550, 100f, "Runoff is poisoning the bay. More equipment and time required."));
            levelManager.levels.Add(Create("Old Landfill", PollutionType.SolidWaste, 500, 110f, "A large neglected landfill. Remediation will take longer."));
            levelManager.levels.Add(Create("Deep Aquifer Threat", PollutionType.Groundwater, 480, 120f, "Chemicals have reached the aquifer. Expect a lengthy extraction process."));
            levelManager.levels.Add(Create("Major Highway Noise", PollutionType.Noise, 450, 100f, "Extensive noise pollution. Multiple barriers needed over many months."));

            Debug.Log($"Generated {levelManager.levels.Count} progressive levels (first 2 unlocked)");
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

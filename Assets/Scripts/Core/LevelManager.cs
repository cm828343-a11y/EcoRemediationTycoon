using UnityEngine;
using System.Collections.Generic;
using EcoRemediationTycoon.Core;
using EcoRemediationTycoon.Pollution;
using EcoRemediationTycoon.Economy;

namespace EcoRemediationTycoon.Core
{
    public class LevelManager : MonoBehaviour
    {
        public List<LevelConfig> levels = new List<LevelConfig>();
        public int currentLevelIndex = 0;

        private void Start()
        {
            if (levels.Count > 0)
                LoadLevel(0);
        }

        public void LoadLevel(int index)
        {
            if (index < 0 || index >= levels.Count) return;

            currentLevelIndex = index;
            var config = levels[index];

            var pollution = FindObjectOfType<PollutionManager>();
            if (pollution)
            {
                pollution.InitializeLevel(config.pollutionType);
                pollution.currentContamination = config.startingContamination;
            }

            if (EconomyManager.Instance)
                EconomyManager.Instance.currentMoney = config.startingBudget;

            Debug.Log($"Loaded level: {config.levelName} - {config.briefing}");
        }

        public void NextLevel()
        {
            LoadLevel(currentLevelIndex + 1);
        }
    }
}

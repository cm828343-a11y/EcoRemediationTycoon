using UnityEngine;
using System.Collections.Generic;
using EcoRemediationTycoon.Pollution;
using EcoRemediationTycoon.Economy;

namespace EcoRemediationTycoon.Core
{
    public class LevelManager : MonoBehaviour
    {
        public List<LevelConfig> levels = new List<LevelConfig>();
        public int currentLevelIndex = 0;
        public int highestUnlockedIndex = 1; // Start with first two levels (0 and 1) unlocked

        public event System.Action OnLevelsChanged;

        private void Start()
        {
            if (levels.Count > 0)
                LoadLevel(0);
        }

        public bool IsUnlocked(int index)
        {
            return index <= highestUnlockedIndex;
        }

        public void LoadLevel(int index)
        {
            if (index < 0 || index >= levels.Count) return;
            if (!IsUnlocked(index))
            {
                Debug.Log("Level locked. Finish the previous level first.");
                return;
            }

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

        public void CompleteCurrentLevel()
        {
            // Unlock the next level
            if (currentLevelIndex + 1 > highestUnlockedIndex && currentLevelIndex + 1 < levels.Count)
            {
                highestUnlockedIndex = currentLevelIndex + 1;
                Debug.Log($"Unlocked level {highestUnlockedIndex + 1}");
                OnLevelsChanged?.Invoke();
            }

            // Optional: auto-advance
            // LoadLevel(currentLevelIndex + 1);
        }

        public void NextLevel()
        {
            LoadLevel(currentLevelIndex + 1);
        }
    }
}

using UnityEngine;
using EcoRemediationTycoon.Economy;
using EcoRemediationTycoon.Pollution;

namespace EcoRemediationTycoon.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("References")]
        public PollutionManager pollutionManager;
        public EconomyManager economyManager;

        public PollutionType currentPollutionType = PollutionType.Water;
        public int currentLevel = 1;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            StartLevel(currentPollutionType);
        }

        public void StartLevel(PollutionType type)
        {
            currentPollutionType = type;
            pollutionManager?.InitializeLevel(type);
            Debug.Log($"Starting level {currentLevel} - Pollution type: {type}");
        }

        public void CompleteLevel()
        {
            currentLevel++;
            Debug.Log($"Level complete! Advancing to level {currentLevel}");
            // TODO: Load next pollution type / scene
        }
    }
}

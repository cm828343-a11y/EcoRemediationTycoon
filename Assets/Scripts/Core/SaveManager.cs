using UnityEngine;
using System.IO;
using EcoRemediationTycoon.Economy;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Core
{
    [System.Serializable]
    public class SaveData
    {
        public int money;
        public int currentLevelIndex;
        public bool advancedUnlocked;
        public int year;
        public int month;
    }

    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance { get; private set; }

        private string savePath;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            savePath = Path.Combine(Application.persistentDataPath, "ecotycoon_save.json");
        }

        private void Start()
        {
            Load();
        }

        public void Save()
        {
            var data = new SaveData
            {
                money = EconomyManager.Instance != null ? EconomyManager.Instance.currentMoney : 500,
                currentLevelIndex = FindObjectOfType<LevelManager>()?.currentLevelIndex ?? 0,
                advancedUnlocked = UnlockManager.Instance != null &&
                                   EconomyManager.Instance != null &&
                                   EconomyManager.Instance.currentMoney >= UnlockManager.Instance.advancedTechThreshold,
                year = TimeManager.Instance != null ? TimeManager.Instance.currentYear : 2026,
                month = TimeManager.Instance != null ? TimeManager.Instance.currentMonth : 1
            };

            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(savePath, json);
            Debug.Log("Game saved");
        }

        public void Load()
        {
            if (!File.Exists(savePath)) return;

            string json = File.ReadAllText(savePath);
            var data = JsonUtility.FromJson<SaveData>(json);

            if (EconomyManager.Instance)
                EconomyManager.Instance.currentMoney = data.money;

            var levelManager = FindObjectOfType<LevelManager>();
            if (levelManager && data.currentLevelIndex < levelManager.levels.Count)
                levelManager.LoadLevel(data.currentLevelIndex);

            if (TimeManager.Instance)
            {
                TimeManager.Instance.currentYear = data.year;
                TimeManager.Instance.currentMonth = data.month;
            }

            Debug.Log("Game loaded");
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause) Save();
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Economy
{
    public class UnlockManager : MonoBehaviour
    {
        public static UnlockManager Instance { get; private set; }

        [Header("Unlocks")]
        public List<EquipmentData> lockedEquipment = new List<EquipmentData>();
        public List<EquipmentData> unlockedEquipment = new List<EquipmentData>();

        public int advancedTechThreshold = 2000; // Money needed to unlock advanced

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public void CheckUnlocks()
        {
            if (EconomyManager.Instance == null) return;

            if (EconomyManager.Instance.currentMoney >= advancedTechThreshold)
            {
                UnlockAllAdvanced();
            }
        }

        private void UnlockAllAdvanced()
        {
            for (int i = lockedEquipment.Count - 1; i >= 0; i--)
            {
                var data = lockedEquipment[i];
                if (data.isAdvanced)
                {
                    unlockedEquipment.Add(data);
                    lockedEquipment.RemoveAt(i);
                    Debug.Log($"Unlocked advanced tech: {data.displayName}");
                }
            }
        }

        public bool IsUnlocked(EquipmentData data)
        {
            return unlockedEquipment.Contains(data);
        }
    }
}

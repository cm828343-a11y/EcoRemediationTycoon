using System.Collections.Generic;
using UnityEngine;
using EcoRemediationTycoon.Core;
using EcoRemediationTycoon.Remediation;

namespace EcoRemediationTycoon.Economy
{
    /// <summary>
    /// Holds all available equipment definitions. Populate in the inspector or at runtime.
    /// Used by the shop and unlock system.
    /// </summary>
    public class EquipmentCatalog : MonoBehaviour
    {
        public static EquipmentCatalog Instance { get; private set; }

        public List<EquipmentData> allEquipment = new List<EquipmentData>();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public List<EquipmentData> GetAvailableFor(PollutionType type, bool includeAdvanced)
        {
            var result = new List<EquipmentData>();
            foreach (var data in allEquipment)
            {
                if (data.pollutionType != type) continue;
                if (data.isAdvanced && !includeAdvanced) continue;
                result.Add(data);
            }
            return result;
        }

        public EquipmentData GetByName(string name)
        {
            return allEquipment.Find(e => e.displayName == name);
        }
    }
}

using UnityEngine;
using EcoRemediationTycoon.Core;
using EcoRemediationTycoon.Remediation;

namespace EcoRemediationTycoon.Economy
{
    /// <summary>
    /// Creates basic EquipmentData assets in memory so the catalog works even before you make ScriptableObjects in the editor.
    /// Call GenerateStarterSet() once (e.g. from SceneSetupHelper or a menu).
    /// </summary>
    public class EquipmentDataFactory : MonoBehaviour
    {
        public void GenerateStarterSet()
        {
            if (EquipmentCatalog.Instance == null) return;

            EquipmentCatalog.Instance.allEquipment.Clear();

            // Basic units
            Add("Basic Water Filter", PollutionType.Water, 150, 3.5f, false);
            Add("Basic Air Scrubber", PollutionType.Air, 160, 3.5f, false);
            Add("Oil Skimmer", PollutionType.OilSpill, 200, 4.0f, false);
            Add("Landfill Cover System", PollutionType.SolidWaste, 180, 3.0f, false);
            Add("Groundwater Extraction Pump", PollutionType.Groundwater, 250, 3.8f, false);
            Add("Acoustic Noise Barrier", PollutionType.Noise, 120, 4.5f, false);

            // Advanced units
            Add("Advanced Membrane Filtration", PollutionType.Water, 400, 7.0f, true);
            Add("Advanced Air Scrubber", PollutionType.Air, 450, 6.5f, true);
            Add("Advanced Oleophilic Skimmer", PollutionType.OilSpill, 500, 8.0f, true);
            Add("Advanced Gas Collection + Cover", PollutionType.SolidWaste, 420, 6.0f, true);
            Add("Advanced Multi-Phase Extraction", PollutionType.Groundwater, 550, 7.5f, true);
            Add("Advanced Active Noise Cancellation", PollutionType.Noise, 350, 9.0f, true);

            Debug.Log($"Generated {EquipmentCatalog.Instance.allEquipment.Count} equipment entries");
        }

        private void Add(string name, PollutionType type, int cost, float rate, bool advanced)
        {
            var data = ScriptableObject.CreateInstance<EquipmentData>();
            data.displayName = name;
            data.pollutionType = type;
            data.cost = cost;
            data.treatmentRate = rate;
            data.isAdvanced = advanced;
            data.description = $"{name} - treats {type} at {rate} points per game month.";

            EquipmentCatalog.Instance.allEquipment.Add(data);
        }
    }
}

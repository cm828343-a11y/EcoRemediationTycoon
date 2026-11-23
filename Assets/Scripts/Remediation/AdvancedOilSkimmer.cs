using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class AdvancedOilSkimmer : TimedRemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Advanced Oleophilic Skimmer";
            supportedPollutionType = PollutionType.OilSpill;
            treatmentPerGameMonth = 8.0f;
            cost = 500;
            isAdvanced = true;
        }
    }
}

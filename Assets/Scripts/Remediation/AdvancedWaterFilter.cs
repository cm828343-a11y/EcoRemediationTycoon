using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class AdvancedWaterFilter : TimedRemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Advanced Membrane Filtration";
            supportedPollutionType = PollutionType.Water;
            treatmentPerGameMonth = 7.0f;
            cost = 400;
            isAdvanced = true;
        }
    }
}

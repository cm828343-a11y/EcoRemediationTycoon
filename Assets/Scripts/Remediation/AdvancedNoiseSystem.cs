using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class AdvancedNoiseSystem : TimedRemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Advanced Active Noise Cancellation";
            supportedPollutionType = PollutionType.Noise;
            treatmentPerGameMonth = 9.0f;
            cost = 350;
            isAdvanced = true;
        }
    }
}

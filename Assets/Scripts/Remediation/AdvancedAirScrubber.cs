using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class AdvancedAirScrubber : RemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Advanced Air Scrubber";
            supportedPollutionType = PollutionType.Air;
            treatmentRatePerSecond = 12f;
            cost = 450;
            isAdvanced = true;
        }
    }
}

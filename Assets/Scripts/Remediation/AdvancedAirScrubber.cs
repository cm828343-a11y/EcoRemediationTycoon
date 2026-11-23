using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class AdvancedAirScrubber : TimedRemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Advanced Air Scrubber";
            supportedPollutionType = PollutionType.Air;
            treatmentPerGameMonth = 6.5f;
            cost = 450;
            isAdvanced = true;
        }
    }
}

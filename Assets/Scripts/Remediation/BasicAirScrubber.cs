using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class BasicAirScrubber : TimedRemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Basic Air Scrubber";
            supportedPollutionType = PollutionType.Air;
            treatmentPerGameMonth = 3.5f;
            cost = 160;
            isAdvanced = false;
        }
    }
}

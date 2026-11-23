using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class GroundwaterPump : TimedRemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Groundwater Extraction Pump";
            supportedPollutionType = PollutionType.Groundwater;
            treatmentPerGameMonth = 3.8f;
            cost = 250;
            isAdvanced = false;
        }
    }
}

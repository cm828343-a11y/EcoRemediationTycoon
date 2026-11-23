using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class GroundwaterPump : RemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Groundwater Extraction Pump";
            supportedPollutionType = PollutionType.Groundwater;
            treatmentRatePerSecond = 5f;
            cost = 250;
            isAdvanced = false;
        }
    }
}

using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class LandfillCoverSystem : RemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Landfill Cover System";
            supportedPollutionType = PollutionType.SolidWaste;
            treatmentRatePerSecond = 3.5f;
            cost = 180;
            isAdvanced = false;
        }
    }
}

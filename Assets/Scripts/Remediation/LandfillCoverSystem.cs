using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class LandfillCoverSystem : TimedRemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Landfill Cover System";
            supportedPollutionType = PollutionType.SolidWaste;
            treatmentPerGameMonth = 3.0f;
            cost = 180;
            isAdvanced = false;
        }
    }
}

using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class AdvancedGroundwaterSystem : TimedRemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Advanced Multi-Phase Extraction";
            supportedPollutionType = PollutionType.Groundwater;
            treatmentPerGameMonth = 7.5f;
            cost = 550;
            isAdvanced = true;
        }
    }
}

using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class AdvancedLandfillSystem : TimedRemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Advanced Gas Collection + Cover";
            supportedPollutionType = PollutionType.SolidWaste;
            treatmentPerGameMonth = 6.0f;
            cost = 420;
            isAdvanced = true;
        }
    }
}

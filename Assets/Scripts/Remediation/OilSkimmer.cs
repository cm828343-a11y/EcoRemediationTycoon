using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class OilSkimmer : RemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Oil Skimmer";
            supportedPollutionType = PollutionType.OilSpill;
            treatmentRatePerSecond = 6f;
            cost = 200;
            isAdvanced = false;
        }
    }
}

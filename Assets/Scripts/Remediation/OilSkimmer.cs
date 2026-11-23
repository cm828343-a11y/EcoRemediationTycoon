using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class OilSkimmer : TimedRemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Oil Skimmer";
            supportedPollutionType = PollutionType.OilSpill;
            treatmentPerGameMonth = 4.0f;
            cost = 200;
            isAdvanced = false;
        }
    }
}

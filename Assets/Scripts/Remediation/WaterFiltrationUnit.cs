using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class WaterFiltrationUnit : TimedRemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Basic Water Filter";
            supportedPollutionType = PollutionType.Water;
            treatmentPerGameMonth = 3.5f;
            cost = 150;
            isAdvanced = false;
        }
    }
}

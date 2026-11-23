using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class WaterFiltrationUnit : RemediationEquipment
    {
        [Header("Water Specific")]
        public float filtrationEfficiency = 1.2f;

        protected override void Start()
        {
            base.Start();
            equipmentName = "Basic Water Filter";
            supportedPollutionType = PollutionType.Water;
            treatmentRatePerSecond = 4f * filtrationEfficiency;
            cost = 150;
            isAdvanced = false;
        }

        public override void Operate(float deltaTime)
        {
            base.Operate(deltaTime);
            // Extra visual/particle effects can go here
        }
    }
}

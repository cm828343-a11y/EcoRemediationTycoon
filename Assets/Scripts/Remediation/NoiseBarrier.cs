using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class NoiseBarrier : RemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Acoustic Noise Barrier";
            supportedPollutionType = PollutionType.Noise;
            treatmentRatePerSecond = 7f;
            cost = 120;
            isAdvanced = false;
        }
    }
}

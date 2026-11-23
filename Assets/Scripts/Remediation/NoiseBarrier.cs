using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class NoiseBarrier : TimedRemediationEquipment
    {
        protected override void Start()
        {
            base.Start();
            equipmentName = "Acoustic Noise Barrier";
            supportedPollutionType = PollutionType.Noise;
            treatmentPerGameMonth = 4.5f;
            cost = 120;
            isAdvanced = false;
        }
    }
}

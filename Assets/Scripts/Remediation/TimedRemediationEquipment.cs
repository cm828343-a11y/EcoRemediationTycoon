using UnityEngine;
using EcoRemediationTycoon.Core;
using EcoRemediationTycoon.Pollution;

namespace EcoRemediationTycoon.Remediation
{
    /// <summary>
    /// Equipment whose effectiveness is measured in game months instead of real seconds.
    /// Example: a water filter that takes 6-12 game months to significantly clean a site.
    /// </summary>
    public class TimedRemediationEquipment : RemediationEquipment
    {
        [Header("Realistic Timing")]
        [Tooltip("Contamination points reduced per game month")]
        public float treatmentPerGameMonth = 8f;

        private TimeManager timeManager;

        protected override void Start()
        {
            base.Start();
            timeManager = TimeManager.Instance;
        }

        public override void Operate(float deltaTime)
        {
            // Ignore real deltaTime; use game time instead
            if (timeManager == null || pollutionManager == null) return;
            if (pollutionManager.activeType != supportedPollutionType) return;

            // Convert current time scale into game months this frame
            float deltaGameMonths = (Time.deltaTime / timeManager.realSecondsPerGameWeek) * timeManager.timeScale / 4.33f;
            float treated = treatmentPerGameMonth * deltaGameMonths;

            pollutionManager.ReduceContamination(treated);
        }
    }
}

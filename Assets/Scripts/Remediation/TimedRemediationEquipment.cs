using UnityEngine;
using EcoRemediationTycoon.Core;
using EcoRemediationTycoon.Pollution;

namespace EcoRemediationTycoon.Remediation
{
    /// <summary>
    /// Equipment whose effectiveness is measured in game months.
    /// Multiple units of the same type stack linearly.
    /// Tuned so a level takes roughly 15-30 real minutes at 4x-8x time scale
    /// once a reasonable number of units are placed.
    /// </summary>
    public class TimedRemediationEquipment : RemediationEquipment
    {
        [Header("Realistic Timing")]
        [Tooltip("Contamination points reduced per game month PER UNIT")]
        public float treatmentPerGameMonth = 3.5f;

        private TimeManager timeManager;

        protected override void Start()
        {
            base.Start();
            timeManager = TimeManager.Instance;
        }

        public override void Operate(float deltaTime)
        {
            if (timeManager == null || pollutionManager == null) return;
            if (pollutionManager.activeType != supportedPollutionType) return;

            // Count how many units of this type are currently active (linear stacking)
            int unitCount = CountActiveUnitsOfType();
            if (unitCount <= 0) unitCount = 1;

            // Game months that pass this frame
            float deltaGameMonths = (Time.deltaTime / timeManager.realSecondsPerGameWeek) * timeManager.timeScale / 4.33f;
            float treated = treatmentPerGameMonth * unitCount * deltaGameMonths;

            pollutionManager.ReduceContamination(treated);
        }

        private int CountActiveUnitsOfType()
        {
            var all = FindObjectsOfType<TimedRemediationEquipment>();
            int count = 0;
            foreach (var eq in all)
            {
                if (eq.supportedPollutionType == supportedPollutionType && eq.isActiveAndEnabled)
                    count++;
            }
            return count;
        }
    }
}

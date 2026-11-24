using UnityEngine;
using EcoRemediationTycoon.Core;
using EcoRemediationTycoon.Pollution;

namespace EcoRemediationTycoon.Core
{
    /// <summary>
    /// Drives seasonal and long-term world changes as time and cleanup progress.
    /// Hook materials, particle systems, tree growth, water color, etc. to the events.
    /// </summary>
    public class WorldVisualsManager : MonoBehaviour
    {
        [Header("Seasonal")]
        public float seasonBlendSpeed = 1f;

        [Header("Pollution Visuals")]
        public Color cleanWaterColor = new Color(0.2f, 0.5f, 0.8f);
        public Color oilyWaterColor = new Color(0.1f, 0.1f, 0.05f);

        public event System.Action<int> OnSeasonChanged; // 0=Winter, 1=Spring, 2=Summer, 3=Fall
        public event System.Action<float> OnWaterQualityChanged; // 0=oily, 1=clean
        public event System.Action<float> OnForestRecoveryChanged; // 0=damaged, 1=mature

        private TimeManager timeManager;
        private PollutionManager pollutionManager;
        private int currentSeason;

        private void Start()
        {
            timeManager = TimeManager.Instance;
            pollutionManager = FindObjectOfType<PollutionManager>();

            if (timeManager != null)
                timeManager.OnMonthChanged += HandleMonthChanged;
        }

        private void HandleMonthChanged(int year, int month)
        {
            int newSeason = GetSeason(month);
            if (newSeason != currentSeason)
            {
                currentSeason = newSeason;
                OnSeasonChanged?.Invoke(currentSeason);
                Debug.Log($"Season changed to {GetSeasonName(currentSeason)}");
            }
        }

        private void Update()
        {
            if (pollutionManager == null) return;

            // Continuous visual updates based on contamination
            float quality = 1f - (pollutionManager.currentContamination / 100f);
            OnWaterQualityChanged?.Invoke(quality);

            // Forest recovery tied to both time and cleanup
            float yearsPassed = (timeManager != null) ? (timeManager.currentYear - timeManager.startYear) : 0f;
            float recovery = Mathf.Clamp01((quality * 0.7f) + (yearsPassed * 0.05f));
            OnForestRecoveryChanged?.Invoke(recovery);
        }

        private int GetSeason(int month)
        {
            if (month >= 12 || month <= 2) return 0; // Winter
            if (month >= 3 && month <= 5) return 1;  // Spring
            if (month >= 6 && month <= 8) return 2;  // Summer
            return 3; // Fall
        }

        private string GetSeasonName(int season)
        {
            return season switch
            {
                0 => "Winter",
                1 => "Spring",
                2 => "Summer",
                3 => "Fall",
                _ => "Unknown"
            };
        }

        private void OnDestroy()
        {
            if (timeManager != null)
                timeManager.OnMonthChanged -= HandleMonthChanged;
        }
    }
}

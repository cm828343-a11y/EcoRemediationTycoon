using UnityEngine;
using System;

namespace EcoRemediationTycoon.Core
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance { get; private set; }

        [Header("Time Settings")]
        // Tuned so a typical cleanup (with several units) takes ~15-30 real minutes at 4x-8x boost
        public float realSecondsPerGameWeek = 8f; // Slower base: 8 real seconds = 1 game week
        public int startYear = 2026;
        public int startMonth = 1;

        [Header("Current Time")]
        public int currentYear;
        public int currentMonth;
        public float currentWeekFraction;

        public float timeScale = 1f; // 1 = normal, 4-8 recommended for play

        public event Action<int, int> OnMonthChanged;
        public event Action<float> OnTimeAdvanced;

        private float accumulatedGameWeeks;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            currentYear = startYear;
            currentMonth = startMonth;
        }

        private void Update()
        {
            float deltaGameWeeks = (Time.deltaTime / realSecondsPerGameWeek) * timeScale;
            accumulatedGameWeeks += deltaGameWeeks;

            OnTimeAdvanced?.Invoke(deltaGameWeeks);

            while (accumulatedGameWeeks >= 4.33f)
            {
                accumulatedGameWeeks -= 4.33f;
                AdvanceMonth();
            }
        }

        private void AdvanceMonth()
        {
            currentMonth++;
            if (currentMonth > 12)
            {
                currentMonth = 1;
                currentYear++;
            }

            OnMonthChanged?.Invoke(currentYear, currentMonth);
            Debug.Log($"Time advanced to {currentMonth}/{currentYear}");
        }

        public void SetTimeScale(float scale)
        {
            timeScale = Mathf.Max(0.1f, scale);
        }

        public string GetDateString()
        {
            return $"{currentMonth:00}/{currentYear}";
        }

        public float GetRealSecondsForMonths(float months)
        {
            float gameWeeks = months * 4.33f;
            return (gameWeeks * realSecondsPerGameWeek) / timeScale;
        }
    }
}

using UnityEngine;
using System;

namespace EcoRemediationTycoon.Core
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance { get; private set; }

        [Header("Time Settings")]
        public float realSecondsPerGameWeek = 1f; // Default speed: 1 real second = 1 game week
        public int startYear = 2026;
        public int startMonth = 1; // 1-12

        [Header("Current Time")]
        public int currentYear;
        public int currentMonth;
        public float currentWeekFraction; // 0-1 within month (approx)

        public float timeScale = 1f; // 1 = normal, higher = faster

        public event Action<int, int> OnMonthChanged; // year, month
        public event Action<float> OnTimeAdvanced;   // delta game weeks

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

            // Advance calendar (rough: 4.33 weeks per month)
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

        // How many real seconds for a given number of game months at current speed
        public float GetRealSecondsForMonths(float months)
        {
            float gameWeeks = months * 4.33f;
            return (gameWeeks * realSecondsPerGameWeek) / timeScale;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.UI
{
    public class TimeUI : MonoBehaviour
    {
        public Text dateText;
        public Button speed1xButton;
        public Button speed4xButton;
        public Button speed16xButton;

        private TimeManager timeManager;

        private void Start()
        {
            timeManager = TimeManager.Instance;
            if (timeManager != null)
            {
                timeManager.OnMonthChanged += UpdateDate;
                UpdateDate(timeManager.currentYear, timeManager.currentMonth);
            }

            if (speed1xButton) speed1xButton.onClick.AddListener(() => SetSpeed(1f));
            if (speed4xButton) speed4xButton.onClick.AddListener(() => SetSpeed(4f));
            if (speed16xButton) speed16xButton.onClick.AddListener(() => SetSpeed(16f));
        }

        private void UpdateDate(int year, int month)
        {
            if (dateText && timeManager != null)
                dateText.text = timeManager.GetDateString();
        }

        private void SetSpeed(float scale)
        {
            timeManager?.SetTimeScale(scale);
            Debug.Log($"Time scale set to {scale}x");
        }

        private void OnDestroy()
        {
            if (timeManager != null)
                timeManager.OnMonthChanged -= UpdateDate;
        }
    }
}

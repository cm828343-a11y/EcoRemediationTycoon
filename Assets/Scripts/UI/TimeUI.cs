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
        public Button speed8xButton;

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
            if (speed8xButton) speed8xButton.onClick.AddListener(() => SetSpeed(8f));
        }

        private void UpdateDate(int year, int month)
        {
            if (dateText && timeManager != null)
                dateText.text = timeManager.GetDateString();
        }

        private void SetSpeed(float scale)
        {
            timeManager?.SetTimeScale(scale);
            Debug.Log($"Time scale set to {scale}x (target ~15-30 min per level at 4x-8x)");
        }

        private void OnDestroy()
        {
            if (timeManager != null)
                timeManager.OnMonthChanged -= UpdateDate;
        }
    }
}

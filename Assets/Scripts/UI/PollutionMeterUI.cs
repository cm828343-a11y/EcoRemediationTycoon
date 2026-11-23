using UnityEngine;
using UnityEngine.UI;
using EcoRemediationTycoon.Pollution;

namespace EcoRemediationTycoon.UI
{
    public class PollutionMeterUI : MonoBehaviour
    {
        public Slider contaminationSlider;
        public Text contaminationText;

        private PollutionManager pollutionManager;

        private void Start()
        {
            pollutionManager = FindObjectOfType<PollutionManager>();
            if (pollutionManager != null)
            {
                pollutionManager.OnContaminationChanged += UpdateMeter;
                UpdateMeter(pollutionManager.currentContamination);
            }
        }

        private void UpdateMeter(float value)
        {
            if (contaminationSlider)
                contaminationSlider.value = value / 100f;

            if (contaminationText)
                contaminationText.text = $"{value:F0}% Contaminated";
        }

        private void OnDestroy()
        {
            if (pollutionManager != null)
                pollutionManager.OnContaminationChanged -= UpdateMeter;
        }
    }
}

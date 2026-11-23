using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Pollution
{
    public class PollutionManager : MonoBehaviour
    {
        [Header("Pollution State")]
        public float currentContamination = 100f; // 0 = clean, 100 = heavily polluted
        public PollutionType activeType;

        public event System.Action<float> OnContaminationChanged;

        public void InitializeLevel(PollutionType type)
        {
            activeType = type;
            currentContamination = 100f;
            OnContaminationChanged?.Invoke(currentContamination);
            Debug.Log($"Pollution system initialized for {type}");
        }

        public void ReduceContamination(float amount)
        {
            currentContamination = Mathf.Max(0f, currentContamination - amount);
            OnContaminationChanged?.Invoke(currentContamination);

            if (currentContamination <= 0f)
            {
                var levelManager = FindObjectOfType<LevelManager>();
                levelManager?.CompleteCurrentLevel();

                GameManager.Instance?.CompleteLevel();
            }
        }

        public bool IsCleanEnough(float threshold = 10f)
        {
            return currentContamination <= threshold;
        }
    }
}

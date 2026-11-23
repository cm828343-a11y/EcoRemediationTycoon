using UnityEngine;
using EcoRemediationTycoon.Pollution;
using EcoRemediationTycoon.Economy;

namespace EcoRemediationTycoon.Economy
{
    /// <summary>
    /// Awards money as contamination is reduced. Faster cleanup = more frequent rewards.
    /// </summary>
    public class CleanupRewardSystem : MonoBehaviour
    {
        public float moneyPerContaminationPoint = 2f;
        public float rewardIntervalSeconds = 5f; // Check every few seconds

        private PollutionManager pollutionManager;
        private float lastContamination;
        private float timer;

        private void Start()
        {
            pollutionManager = FindObjectOfType<PollutionManager>();
            if (pollutionManager)
                lastContamination = pollutionManager.currentContamination;
        }

        private void Update()
        {
            if (pollutionManager == null || EconomyManager.Instance == null) return;

            timer += Time.deltaTime;
            if (timer < rewardIntervalSeconds) return;
            timer = 0f;

            float reduced = lastContamination - pollutionManager.currentContamination;
            if (reduced > 0.1f)
            {
                int reward = Mathf.RoundToInt(reduced * moneyPerContaminationPoint);
                EconomyManager.Instance.Earn(reward);
                Debug.Log($"Cleanup reward: +${reward}");
            }

            lastContamination = pollutionManager.currentContamination;
        }
    }
}

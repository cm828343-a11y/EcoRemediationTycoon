using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Pollution
{
    public class ContaminationTester : MonoBehaviour
    {
        [Header("Testing")]
        public float testCost = 25f;
        public float testDuration = 2f;

        private PollutionManager pollutionManager;
        private bool isTesting;

        private void Start()
        {
            pollutionManager = FindObjectOfType<PollutionManager>();
        }

        public void StartTest()
        {
            if (isTesting || pollutionManager == null) return;

            // Optional: spend money to test
            // if (!EconomyManager.Instance.Spend((int)testCost)) return;

            isTesting = true;
            Debug.Log($"Testing {pollutionManager.activeType} contamination...");
            Invoke(nameof(CompleteTest), testDuration);
        }

        private void CompleteTest()
        {
            isTesting = false;
            float level = pollutionManager.currentContamination;
            string status = level > 70 ? "Severe" : level > 30 ? "Moderate" : "Low";
            Debug.Log($"Test complete: {status} contamination ({level:F1}%)");
            // Hook this to UI
        }

        public bool IsTesting => isTesting;
    }
}

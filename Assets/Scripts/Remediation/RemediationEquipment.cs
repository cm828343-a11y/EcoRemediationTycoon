using UnityEngine;
using EcoRemediationTycoon.Core;
using EcoRemediationTycoon.Pollution;

namespace EcoRemediationTycoon.Remediation
{
    public abstract class RemediationEquipment : MonoBehaviour
    {
        [Header("Equipment Stats")]
        public string equipmentName;
        public PollutionType supportedPollutionType;
        public float treatmentRatePerSecond = 5f;
        public int cost = 100;
        public bool isAdvanced = false;

        protected PollutionManager pollutionManager;

        protected virtual void Start()
        {
            pollutionManager = FindObjectOfType<PollutionManager>();
        }

        public virtual void Place()
        {
            Debug.Log($"Placed {equipmentName} for {supportedPollutionType}");
        }

        public virtual void Operate(float deltaTime)
        {
            if (pollutionManager != null && pollutionManager.activeType == supportedPollutionType)
            {
                float treated = treatmentRatePerSecond * deltaTime;
                pollutionManager.ReduceContamination(treated);
            }
        }
    }
}

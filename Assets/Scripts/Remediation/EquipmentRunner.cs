using UnityEngine;

namespace EcoRemediationTycoon.Remediation
{
    /// <summary>
    /// Attach to a parent object or use on a manager to tick all placed equipment.
    /// </summary>
    public class EquipmentRunner : MonoBehaviour
    {
        private RemediationEquipment[] activeEquipment;

        private void Update()
        {
            activeEquipment = FindObjectsOfType<RemediationEquipment>();
            foreach (var eq in activeEquipment)
            {
                eq.Operate(Time.deltaTime);
            }
        }
    }
}

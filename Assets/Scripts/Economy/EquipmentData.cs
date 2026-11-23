using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Economy
{
    [CreateAssetMenu(fileName = "EquipmentData", menuName = "EcoTycoon/Equipment Data")]
    public class EquipmentData : ScriptableObject
    {
        public string displayName;
        public PollutionType pollutionType;
        public int cost;
        public float treatmentRate;
        public bool isAdvanced;
        public GameObject prefab;
        public Sprite icon;

        [TextArea]
        public string description;
    }
}

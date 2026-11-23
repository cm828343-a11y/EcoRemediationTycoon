using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EcoRemediationTycoon.Core;
using EcoRemediationTycoon.Economy;
using EcoRemediationTycoon.Remediation;

namespace EcoRemediationTycoon.UI
{
    /// <summary>
    /// Simple shop UI that lists equipment for the current pollution type.
    /// Wire buttons or a scroll view to the generated entries.
    /// </summary>
    public class EquipmentShopUI : MonoBehaviour
    {
        public Transform buttonContainer;
        public GameObject equipmentButtonPrefab; // Prefab with Button + Text

        private PlacementSystem placementSystem;
        private UnlockManager unlockManager;

        private void Start()
        {
            placementSystem = FindObjectOfType<PlacementSystem>();
            unlockManager = UnlockManager.Instance;
            RefreshShop();
        }

        public void RefreshShop()
        {
            if (buttonContainer == null || EquipmentCatalog.Instance == null) return;

            // Clear old buttons
            foreach (Transform child in buttonContainer)
                Destroy(child.gameObject);

            var type = GameManager.Instance != null ? GameManager.Instance.currentPollutionType : PollutionType.Water;
            bool advancedUnlocked = unlockManager != null && EconomyManager.Instance != null &&
                                    EconomyManager.Instance.currentMoney >= unlockManager.advancedTechThreshold;

            var available = EquipmentCatalog.Instance.GetAvailableFor(type, advancedUnlocked);

            foreach (var data in available)
            {
                if (equipmentButtonPrefab == null) continue;

                var go = Instantiate(equipmentButtonPrefab, buttonContainer);
                var btn = go.GetComponent<Button>();
                var label = go.GetComponentInChildren<Text>();

                if (label) label.text = $"{data.displayName}\n${data.cost}";
                if (btn) btn.onClick.AddListener(() => SelectEquipment(data));
            }
        }

        private void SelectEquipment(EquipmentData data)
        {
            if (data.prefab == null)
            {
                Debug.LogWarning($"No prefab assigned for {data.displayName}");
                return;
            }

            var equip = data.prefab.GetComponent<RemediationEquipment>();
            if (equip && placementSystem)
                placementSystem.StartPlacement(equip);
        }
    }
}

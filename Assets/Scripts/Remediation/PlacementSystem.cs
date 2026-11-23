using UnityEngine;
using EcoRemediationTycoon.Economy;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Remediation
{
    public class PlacementSystem : MonoBehaviour
    {
        [Header("Placement")]
        public LayerMask placementLayer;
        public GameObject placementPreviewPrefab;

        private RemediationEquipment selectedEquipmentPrefab;
        private GameObject currentPreview;
        private bool isPlacing;

        public void StartPlacement(RemediationEquipment equipmentPrefab)
        {
            if (!EconomyManager.Instance || !EconomyManager.Instance.CanAfford(equipmentPrefab.cost))
            {
                Debug.Log("Not enough money");
                return;
            }

            selectedEquipmentPrefab = equipmentPrefab;
            isPlacing = true;

            if (placementPreviewPrefab)
            {
                currentPreview = Instantiate(placementPreviewPrefab);
            }
        }

        private void Update()
        {
            if (!isPlacing || selectedEquipmentPrefab == null) return;

            // Raycast for placement position (touch/mouse)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, placementLayer))
            {
                if (currentPreview)
                    currentPreview.transform.position = hit.point;

                if (Input.GetMouseButtonDown(0))
                {
                    PlaceEquipment(hit.point);
                }
            }

            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))
            {
                CancelPlacement();
            }
        }

        private void PlaceEquipment(Vector3 position)
        {
            if (EconomyManager.Instance.Spend(selectedEquipmentPrefab.cost))
            {
                var placed = Instantiate(selectedEquipmentPrefab, position, Quaternion.identity);
                placed.Place();
                Debug.Log($"Placed {placed.equipmentName} at {position}");
            }

            CancelPlacement();
        }

        public void CancelPlacement()
        {
            isPlacing = false;
            selectedEquipmentPrefab = null;
            if (currentPreview) Destroy(currentPreview);
        }
    }
}

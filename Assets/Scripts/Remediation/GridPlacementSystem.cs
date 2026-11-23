using UnityEngine;
using EcoRemediationTycoon.Economy;

namespace EcoRemediationTycoon.Remediation
{
    /// <summary>
    /// Alternative to free placement. Snaps equipment to a grid.
    /// Use this instead of (or alongside) PlacementSystem for a more tycoon-like feel.
    /// </summary>
    public class GridPlacementSystem : MonoBehaviour
    {
        [Header("Grid")]
        public float cellSize = 2f;
        public LayerMask groundLayer;

        private RemediationEquipment selectedPrefab;
        private GameObject preview;
        private bool isPlacing;

        public void StartPlacement(RemediationEquipment prefab)
        {
            if (EconomyManager.Instance == null || !EconomyManager.Instance.CanAfford(prefab.cost))
            {
                Debug.Log("Cannot afford equipment");
                return;
            }

            selectedPrefab = prefab;
            isPlacing = true;

            if (preview) Destroy(preview);
            preview = Instantiate(prefab.gameObject);
            // Disable the real component on the preview so it doesn't treat
            var eq = preview.GetComponent<RemediationEquipment>();
            if (eq) eq.enabled = false;
        }

        private void Update()
        {
            if (!isPlacing || selectedPrefab == null) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 200f, groundLayer))
            {
                Vector3 snapped = SnapToGrid(hit.point);
                if (preview) preview.transform.position = snapped;

                if (Input.GetMouseButtonDown(0))
                    ConfirmPlacement(snapped);
            }

            if (Input.GetMouseButtonDown(1))
                Cancel();
        }

        private Vector3 SnapToGrid(Vector3 worldPos)
        {
            float x = Mathf.Round(worldPos.x / cellSize) * cellSize;
            float z = Mathf.Round(worldPos.z / cellSize) * cellSize;
            return new Vector3(x, worldPos.y, z);
        }

        private void ConfirmPlacement(Vector3 position)
        {
            if (EconomyManager.Instance.Spend(selectedPrefab.cost))
            {
                var placed = Instantiate(selectedPrefab, position, Quaternion.identity);
                placed.Place();
            }
            Cancel();
        }

        public void Cancel()
        {
            isPlacing = false;
            selectedPrefab = null;
            if (preview) Destroy(preview);
        }
    }
}

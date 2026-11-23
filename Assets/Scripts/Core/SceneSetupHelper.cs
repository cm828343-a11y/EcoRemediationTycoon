using UnityEngine;
using EcoRemediationTycoon.Core;
using EcoRemediationTycoon.Pollution;
using EcoRemediationTycoon.Economy;
using EcoRemediationTycoon.Remediation;

namespace EcoRemediationTycoon.Core
{
    /// <summary>
    /// Drop this on an empty GameObject in a new scene to ensure all core managers exist.
    /// Useful for quick testing.
    /// </summary>
    public class SceneSetupHelper : MonoBehaviour
    {
        private void Awake()
        {
            Ensure<GameManager>();
            Ensure<TimeManager>();
            Ensure<PollutionManager>();
            Ensure<EconomyManager>();
            Ensure<UnlockManager>();
            Ensure<EquipmentCatalog>();
            Ensure<SaveManager>();
            Ensure<CleanupRewardSystem>();
            Ensure<WorldVisualsManager>();
            Ensure<LevelManager>();
            Ensure<PlacementSystem>();
            Ensure<EquipmentRunner>();
        }

        private void Ensure<T>() where T : Component
        {
            if (FindObjectOfType<T>() == null)
            {
                var go = new GameObject(typeof(T).Name);
                go.AddComponent<T>();
                Debug.Log($"Created missing {typeof(T).Name}");
            }
        }
    }
}

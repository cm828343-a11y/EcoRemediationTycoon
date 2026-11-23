using UnityEngine;
using EcoRemediationTycoon.Core;
using EcoRemediationTycoon.Economy;
using EcoRemediationTycoon.UI;

namespace EcoRemediationTycoon.Core
{
    /// <summary>
    /// One-click bootstrap. Add this to an empty GameObject and it will
    /// create managers, generate sample levels + equipment, and start the tutorial if needed.
    /// </summary>
    public class GameBootstrap : MonoBehaviour
    {
        private void Awake()
        {
            // Ensure core systems exist
            var setup = gameObject.AddComponent<SceneSetupHelper>();
            // SceneSetupHelper runs in Awake, so we call it explicitly if needed
            // (it already runs automatically)

            // Generate content
            var factory = gameObject.AddComponent<EquipmentDataFactory>();
            factory.GenerateStarterSet();

            var levels = gameObject.AddComponent<SampleLevelConfigs>();
            levels.GenerateSampleLevels();

            // First launch / tutorial
            var tutorial = FindObjectOfType<TutorialManager>();
            if (tutorial == null)
            {
                var tutGo = new GameObject("TutorialManager");
                tutorial = tutGo.AddComponent<TutorialManager>();
            }

            var firstLaunch = gameObject.AddComponent<FirstLaunchManager>();
            firstLaunch.tutorialManager = tutorial;
            firstLaunch.equipmentFactory = factory;
        }
    }
}

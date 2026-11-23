using UnityEngine;
using EcoRemediationTycoon.UI;
using EcoRemediationTycoon.Economy;

namespace EcoRemediationTycoon.Core
{
    /// <summary>
    /// Runs once on first launch: generates starter equipment data and offers the tutorial.
    /// </summary>
    public class FirstLaunchManager : MonoBehaviour
    {
        public TutorialManager tutorialManager;
        public EquipmentDataFactory equipmentFactory;

        private void Start()
        {
            if (equipmentFactory)
                equipmentFactory.GenerateStarterSet();

            if (tutorialManager && !tutorialManager.HasCompletedTutorial())
            {
                // Optional: delay a frame so other systems are ready
                Invoke(nameof(StartTutorial), 0.5f);
            }
        }

        private void StartTutorial()
        {
            tutorialManager.StartTutorial();
        }
    }
}

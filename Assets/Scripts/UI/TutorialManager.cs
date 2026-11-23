using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace EcoRemediationTycoon.UI
{
    /// <summary>
    /// Lightweight step-by-step tutorial. Attach to a panel with a Text field.
    /// Call StartTutorial() from a button or on first launch.
    /// </summary>
    public class TutorialManager : MonoBehaviour
    {
        public GameObject tutorialPanel;
        public Text tutorialText;
        public Button nextButton;

        private string[] steps =
        {
            "Welcome to Eco Remediation Tycoon! Your job is to clean polluted sites.",
            "First, test the contamination level to see how bad it is.",
            "Choose remediation equipment from the shop and place it within your budget.",
            "Speed up time (4x or 8x) and watch the cleanup progress over months and years.",
            "As pollution drops you earn money. Reach enough money to unlock advanced technology.",
            "Clean the site completely to finish the level and move to the next polluted location.",
            "Seasons change and the environment recovers as you succeed. Good luck!"
        };

        private int currentStep;

        private void Start()
        {
            if (nextButton)
                nextButton.onClick.AddListener(NextStep);

            if (tutorialPanel)
                tutorialPanel.SetActive(false);
        }

        public void StartTutorial()
        {
            currentStep = 0;
            if (tutorialPanel) tutorialPanel.SetActive(true);
            ShowStep();
        }

        private void NextStep()
        {
            currentStep++;
            if (currentStep >= steps.Length)
            {
                EndTutorial();
                return;
            }
            ShowStep();
        }

        private void ShowStep()
        {
            if (tutorialText)
                tutorialText.text = steps[currentStep];
        }

        private void EndTutorial()
        {
            if (tutorialPanel) tutorialPanel.SetActive(false);
            PlayerPrefs.SetInt("TutorialCompleted", 1);
            Debug.Log("Tutorial completed");
        }

        public bool HasCompletedTutorial()
        {
            return PlayerPrefs.GetInt("TutorialCompleted", 0) == 1;
        }
    }
}

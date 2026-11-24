using UnityEngine;
using UnityEngine.UI;

namespace EcoRemediationTycoon.UI
{
    /// <summary>
    /// Lightweight step-by-step tutorial.
    /// If no UI is assigned, it creates a simple one automatically.
    /// </summary>
    public class TutorialManager : MonoBehaviour
    {
        public GameObject tutorialPanel;
        public Text tutorialText;
        public Button nextButton;

        private string[] steps =
        {
            "Welcome to Eco Remediation Tycoon!\nYour job is to clean polluted sites.",
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
            if (tutorialPanel == null)
                CreateDefaultUI();

            if (nextButton)
                nextButton.onClick.AddListener(NextStep);

            if (tutorialPanel)
                tutorialPanel.SetActive(false);
        }

        private void CreateDefaultUI()
        {
            // Canvas
            var canvasGo = new GameObject("TutorialCanvas");
            var canvas = canvasGo.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasGo.AddComponent<CanvasScaler>();
            canvasGo.AddComponent<GraphicRaycaster>();

            // Panel
            var panelGo = new GameObject("TutorialPanel");
            panelGo.transform.SetParent(canvasGo.transform, false);
            var panelImage = panelGo.AddComponent<Image>();
            panelImage.color = new Color(0, 0, 0, 0.75f);
            var panelRect = panelGo.GetComponent<RectTransform>();
            panelRect.anchorMin = new Vector2(0.1f, 0.3f);
            panelRect.anchorMax = new Vector2(0.9f, 0.7f);
            panelRect.offsetMin = Vector2.zero;
            panelRect.offsetMax = Vector2.zero;

            // Text
            var textGo = new GameObject("TutorialText");
            textGo.transform.SetParent(panelGo.transform, false);
            tutorialText = textGo.AddComponent<Text>();
            tutorialText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            tutorialText.fontSize = 28;
            tutorialText.color = Color.white;
            tutorialText.alignment = TextAnchor.MiddleCenter;
            var textRect = textGo.GetComponent<RectTransform>();
            textRect.anchorMin = new Vector2(0.05f, 0.3f);
            textRect.anchorMax = new Vector2(0.95f, 0.9f);
            textRect.offsetMin = Vector2.zero;
            textRect.offsetMax = Vector2.zero;

            // Button
            var buttonGo = new GameObject("NextButton");
            buttonGo.transform.SetParent(panelGo.transform, false);
            var buttonImage = buttonGo.AddComponent<Image>();
            buttonImage.color = new Color(0.2f, 0.6f, 0.2f);
            nextButton = buttonGo.AddComponent<Button>();
            var buttonRect = buttonGo.GetComponent<RectTransform>();
            buttonRect.anchorMin = new Vector2(0.3f, 0.05f);
            buttonRect.anchorMax = new Vector2(0.7f, 0.25f);
            buttonRect.offsetMin = Vector2.zero;
            buttonRect.offsetMax = Vector2.zero;

            var buttonTextGo = new GameObject("ButtonText");
            buttonTextGo.transform.SetParent(buttonGo.transform, false);
            var buttonText = buttonTextGo.AddComponent<Text>();
            buttonText.text = "Next";
            buttonText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            buttonText.fontSize = 24;
            buttonText.color = Color.white;
            buttonText.alignment = TextAnchor.MiddleCenter;
            var btRect = buttonTextGo.GetComponent<RectTransform>();
            btRect.anchorMin = Vector2.zero;
            btRect.anchorMax = Vector2.one;
            btRect.offsetMin = Vector2.zero;
            btRect.offsetMax = Vector2.zero;

            tutorialPanel = panelGo;
            Debug.Log("Created default tutorial UI");
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

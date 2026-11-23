using UnityEngine;
using UnityEngine.UI;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.UI
{
    public class LevelSelectUI : MonoBehaviour
    {
        public Transform buttonContainer;
        public GameObject levelButtonPrefab;

        private LevelManager levelManager;

        private void Start()
        {
            levelManager = FindObjectOfType<LevelManager>();
            Refresh();
        }

        public void Refresh()
        {
            if (buttonContainer == null || levelManager == null) return;

            foreach (Transform child in buttonContainer)
                Destroy(child.gameObject);

            for (int i = 0; i < levelManager.levels.Count; i++)
            {
                int index = i; // capture for closure
                var config = levelManager.levels[i];

                if (levelButtonPrefab == null) continue;

                var go = Instantiate(levelButtonPrefab, buttonContainer);
                var btn = go.GetComponent<Button>();
                var label = go.GetComponentInChildren<Text>();

                if (label)
                    label.text = $"{i + 1}. {config.levelName}\n({config.pollutionType})";

                if (btn)
                    btn.onClick.AddListener(() => levelManager.LoadLevel(index));
            }
        }
    }
}

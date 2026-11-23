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
            if (levelManager != null)
                levelManager.OnLevelsChanged += Refresh;

            Refresh();
        }

        public void Refresh()
        {
            if (buttonContainer == null || levelManager == null) return;

            foreach (Transform child in buttonContainer)
                Destroy(child.gameObject);

            for (int i = 0; i < levelManager.levels.Count; i++)
            {
                int index = i;
                var config = levelManager.levels[i];
                bool unlocked = levelManager.IsUnlocked(index);

                if (levelButtonPrefab == null) continue;

                var go = Instantiate(levelButtonPrefab, buttonContainer);
                var btn = go.GetComponent<Button>();
                var label = go.GetComponentInChildren<Text>();

                if (label)
                {
                    string status = unlocked ? "" : " [LOCKED]";
                    label.text = $"{i + 1}. {config.levelName}{status}\n({config.pollutionType})";
                    label.color = unlocked ? Color.white : Color.gray;
                }

                if (btn)
                {
                    btn.interactable = unlocked;
                    if (unlocked)
                        btn.onClick.AddListener(() => levelManager.LoadLevel(index));
                }
            }
        }

        private void OnDestroy()
        {
            if (levelManager != null)
                levelManager.OnLevelsChanged -= Refresh;
        }
    }
}

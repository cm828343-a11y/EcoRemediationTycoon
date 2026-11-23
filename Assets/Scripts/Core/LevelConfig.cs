using UnityEngine;
using EcoRemediationTycoon.Core;

namespace EcoRemediationTycoon.Core
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "EcoTycoon/Level Config")]
    public class LevelConfig : ScriptableObject
    {
        public string levelName;
        public PollutionType pollutionType;
        public int startingBudget = 500;
        public float startingContamination = 100f;
        public string sceneName;

        [TextArea]
        public string briefing;
    }
}

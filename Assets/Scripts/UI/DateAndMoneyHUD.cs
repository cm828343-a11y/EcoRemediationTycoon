using UnityEngine;
using UnityEngine.UI;
using EcoRemediationTycoon.Core;
using EcoRemediationTycoon.Economy;

namespace EcoRemediationTycoon.UI
{
    public class DateAndMoneyHUD : MonoBehaviour
    {
        public Text dateText;
        public Text moneyText;
        public Text contaminationText;

        private void Update()
        {
            if (TimeManager.Instance && dateText)
                dateText.text = TimeManager.Instance.GetDateString();

            if (EconomyManager.Instance && moneyText)
                moneyText.text = $"${EconomyManager.Instance.currentMoney}";

            var pollution = FindObjectOfType<Pollution.PollutionManager>();
            if (pollution && contaminationText)
                contaminationText.text = $"{pollution.currentContamination:F0}%";
        }
    }
}

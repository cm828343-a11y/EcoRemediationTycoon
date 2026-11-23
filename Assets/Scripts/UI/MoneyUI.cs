using UnityEngine;
using UnityEngine.UI;
using EcoRemediationTycoon.Economy;

namespace EcoRemediationTycoon.UI
{
    public class MoneyUI : MonoBehaviour
    {
        public Text moneyText;

        private void Start()
        {
            if (EconomyManager.Instance != null)
            {
                EconomyManager.Instance.OnMoneyChanged += UpdateMoney;
                UpdateMoney(EconomyManager.Instance.currentMoney);
            }
        }

        private void UpdateMoney(int amount)
        {
            if (moneyText)
                moneyText.text = $"${amount}";
        }

        private void OnDestroy()
        {
            if (EconomyManager.Instance != null)
                EconomyManager.Instance.OnMoneyChanged -= UpdateMoney;
        }
    }
}

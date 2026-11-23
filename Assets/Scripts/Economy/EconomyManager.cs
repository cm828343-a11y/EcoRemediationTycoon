using UnityEngine;

namespace EcoRemediationTycoon.Economy
{
    public class EconomyManager : MonoBehaviour
    {
        public static EconomyManager Instance { get; private set; }

        public int currentMoney = 500;

        public event System.Action<int> OnMoneyChanged;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public bool CanAfford(int cost)
        {
            return currentMoney >= cost;
        }

        public bool Spend(int amount)
        {
            if (!CanAfford(amount)) return false;

            currentMoney -= amount;
            OnMoneyChanged?.Invoke(currentMoney);
            return true;
        }

        public void Earn(int amount)
        {
            currentMoney += amount;
            OnMoneyChanged?.Invoke(currentMoney);
        }

        // Call this periodically as pollution is reduced
        public void RewardForCleanup(float contaminationReduced)
        {
            int reward = Mathf.RoundToInt(contaminationReduced * 2f);
            Earn(reward);
        }
    }
}

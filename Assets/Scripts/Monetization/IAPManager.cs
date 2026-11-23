using UnityEngine;
using EcoRemediationTycoon.Economy;

namespace EcoRemediationTycoon.Monetization
{
    /// <summary>
    /// Placeholder for in-app purchases.
    /// Later replace the debug methods with real StoreKit / RevenueCat calls.
    /// </summary>
    public class IAPManager : MonoBehaviour
    {
        public static IAPManager Instance { get; private set; }

        [Header("Product IDs (set these in App Store Connect)")]
        public string removeAdsProductId = "com.yourcompany.ecoremediation.removeads";
        public string starterPackProductId = "com.yourcompany.ecoremediation.starterpack";
        public string advancedUnlockProductId = "com.yourcompany.ecoremediation.advancedunlock";

        public bool adsRemoved;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // Call these from UI buttons for now
        public void BuyRemoveAds()
        {
            Debug.Log("IAP: Remove Ads purchased (placeholder)");
            adsRemoved = true;
            PlayerPrefs.SetInt("AdsRemoved", 1);
        }

        public void BuyStarterPack()
        {
            Debug.Log("IAP: Starter Pack purchased (placeholder)");
            if (EconomyManager.Instance)
                EconomyManager.Instance.Earn(1000);
        }

        public void BuyAdvancedUnlock()
        {
            Debug.Log("IAP: Advanced Unlock purchased (placeholder)");
            // Force unlock by giving enough money or setting a flag
            if (EconomyManager.Instance && UnlockManager.Instance)
                EconomyManager.Instance.Earn(UnlockManager.Instance.advancedTechThreshold);
        }

        public bool AreAdsRemoved()
        {
            return adsRemoved || PlayerPrefs.GetInt("AdsRemoved", 0) == 1;
        }
    }
}

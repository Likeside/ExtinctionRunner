using UnityEngine;
using UnityEngine.Advertisements;

namespace ExtinctionRunner.Controllers
{
    public static class AdsManager
    {
        private static string gameId = "4133487";
        private static bool isTestMode = false;
        private static string bannerId = "Banner_Android";

        public static void InitializeAdsManager()
        {
            Advertisement.Initialize(gameId, isTestMode);
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        }

        public static void ShowInterstitialAd()
        {
            if (Advertisement.IsReady() && PlayerPrefs.GetInt("AdsDisabled") != 1)
            {
                Advertisement.Show();
            }
        }

        public static void ShowBannerAd()
        {
            if (Advertisement.IsReady(bannerId) && PlayerPrefs.GetInt("AdsDisabled") != 1)
            {
                Advertisement.Banner.Show(bannerId);
            }
        }

        public static void CloseBannerAd()
        {
            Advertisement.Banner.Hide();
        }

        public static void DisableAds()
        {
            PlayerPrefs.SetInt("AdsDisabled", 1);
        }

        public static bool CheckIfAdsDisabled()
        {
            if (PlayerPrefs.GetInt("AdsDisabled") == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

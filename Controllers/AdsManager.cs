using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Advertisements;

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
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    public static void ShowBannerAd()
    {
        if (Advertisement.IsReady(bannerId))
        {
            Advertisement.Banner.Show(bannerId);
        }
    }
}

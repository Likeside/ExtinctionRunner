using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using Views;

public static class AdsManager
{
    private static string gameId = "4133487";
    private static bool isTestMode = false;
    private static string bannerId = "Banner_Android";
  //  private static CloseBannerView _closeBannerView;
    public static void InitializeAdsManager()
    {
        Advertisement.Initialize(gameId, isTestMode);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
       // _closeBannerView = GameObject.FindObjectOfType<CloseBannerView>();
       // _closeBannerView.gameObject.SetActive(false);
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
         //_closeBannerView.gameObject.SetActive(true);
        }
    }

    public static void CloseBannerAd()
    {
       // _closeBannerView.gameObject.SetActive(false);
        Advertisement.Banner.Hide();
    }

    public static void DisableAds()
    {
        PlayerPrefs.SetInt("AdsDisabled", 1);
    }
}

using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class CloseBannerView: MonoBehaviour
    {
        public void CloseBanner()
        {
            AdsManager.CloseBannerAd();
        }
    }
}
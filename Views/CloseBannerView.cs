using UnityEngine;

namespace Views
{
    public class CloseBannerView: MonoBehaviour
    {
        public void CloseBanner()
        {
            AdsManager.CloseBannerAd();
        }
    }
}
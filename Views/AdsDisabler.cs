using ExtinctionRunner.Controllers;
using UnityEngine;

namespace ExtinctionRunner.Views
{
  public class AdsDisabler : MonoBehaviour
  {
    [SerializeField] private GameObject _purchaseFailedPanel;
    [SerializeField] private GameObject _purchaseCompletedPanel;

    private void Start()
    {
      _purchaseFailedPanel.SetActive(false);
      if (AdsManager.CheckIfAdsDisabled())
      {
        _purchaseCompletedPanel.SetActive(true);
      }
      else
      {
        _purchaseCompletedPanel.SetActive(false);
      }
    }

    public void AdsDisabledPurchase()
    {
      AdsManager.DisableAds();
      _purchaseCompletedPanel.SetActive(true);
    }

    public void AdsDisabledPurchaseFail()
    {
      _purchaseFailedPanel.SetActive(true);
    }
  }
}

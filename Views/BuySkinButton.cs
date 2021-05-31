using ExtinctionRunner.Controllers;
using ExtinctionRunner.SavingGame;
using TMPro;
using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class BuySkinButton: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private SetSkinActiveButton _button;
        [SerializeField] private GameObject _priceDisplay;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private GameObject _notEnoughVolcanoesPanel;

        private void Start()
        {
            _notEnoughVolcanoesPanel.SetActive(false);
            if (PlayerPrefs.GetInt("PredatorBought") == 1)
            {
                this.gameObject.SetActive(false);
                _priceDisplay.SetActive(false);
            }
            else
            {
                _button.gameObject.SetActive(false);
                _priceText.text = PlayerSpriteManager.PredatorSkinPrice.ToString();
            }
        }

        public void BuySkin()
        {
         bool succes = PlayerSpriteManager.BuyPredatorSkin();
         if (succes)
         {
             _text.text = ScoreManager.TotalScore.ToString();
             SaveSystem.SaveGame();
             _button.gameObject.SetActive(true);
             this.gameObject.SetActive(false);
             _priceDisplay.SetActive(false);
         }
         else
         {
             _notEnoughVolcanoesPanel.SetActive(true);
         }
        }
    }
}
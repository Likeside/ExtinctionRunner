using System;
using Controllers;
using SavingGame;
using TMPro;
using UnityEngine;

namespace Views
{
    public class BuySkinButton: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private SetSkinActiveButton _button;
        [SerializeField] private GameObject _priceDisplay;
        [SerializeField] private TextMeshProUGUI _priceText;

        private void Start()
        {
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
             //обновить отобраджение валюты у игрока, сделать активной кнопку с выбором скина
             _text.text = ScoreManager.TotalScore.ToString();
             SaveSystem.SaveGame();
             _button.gameObject.SetActive(true);
             this.gameObject.SetActive(false);
             _priceDisplay.SetActive(false);
         }
        }
    }
}
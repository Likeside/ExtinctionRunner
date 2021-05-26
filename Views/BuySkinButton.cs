using Controllers;
using TMPro;
using UnityEngine;

namespace Views
{
    public class BuySkinButton: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        public void BuySkin()
        {
         bool succes = PlayerSpriteManager.BuyPredatorSkin();
         if (succes)
         {
             //обновить отобраджение валюты у игрока, сделать активной кнопку с выбором скина
             _text.text = ScoreManager.TotalScore.ToString();
         }
        }
    }
}
using System;
using Controllers;
using TMPro;
using UnityEngine;

namespace Views
{
    public class PlayersCurrencyDisplay: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void Start()
        {
            _text.text = ScoreManager.TotalScore.ToString();
        }
    }
}
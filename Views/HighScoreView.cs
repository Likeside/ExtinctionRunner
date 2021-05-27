using System;
using Controllers;
using TMPro;
using UnityEngine;

namespace Views
{
    public class HighScoreView: MonoBehaviour
    {
        [SerializeField] private int _position;
        [SerializeField] private TextMeshProUGUI _text;
        

        private void Awake()
        {
            _text.text = HighScoreManager.highScore[_position].ToString();
        }
    }
}
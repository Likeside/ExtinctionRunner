using System;
using Controllers;
using UnityEngine;

namespace Views
{
    public class ScoreInitializer: MonoBehaviour
    {
        private void Awake()
        {
            ScoreManager.InitializeScore();
            HighScoreManager.InitializeHighScore();
        }
    }
}
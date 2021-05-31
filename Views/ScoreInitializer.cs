using Controllers;
using UnityEngine;

namespace ExtinctionRunner.Views
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
using ExtinctionRunner;
using UnityEngine;

namespace Controllers
{
    public static class PlayerSpriteManager
    {
        public static Track idle;
        public static Track jump;
        public static Track walk;
        private static int _predatorSkinPrice = 1000;

        public static void Initialize()
        {
            if (PlayerPrefs.GetInt("PredatorActive") == 1)
            {
                idle = Track.IdlePredator;
                jump = Track.JumpPredator;
                walk = Track.WalkPredator;
            }
            else
            {
                idle = Track.Idle;
                jump = Track.Jump;
                walk = Track.Walk;
            }
        }


        public static void SetPredatorActive()
        {
            if (PlayerPrefs.GetInt("PredatorBought") == 1)
            {
                PlayerPrefs.SetInt("PredatorActive", 1);
            }
        }

        public static void SetHerbiActive()
        {
            PlayerPrefs.SetInt("PredatorActive", 0);
        }

        public static bool BuyPredatorSkin()
        {
            bool succes = false;
            if (ScoreManager.TotalScore >= _predatorSkinPrice)
            {
                PlayerPrefs.SetInt("PredatorBought", 1);
                ScoreManager.RemoveScore(_predatorSkinPrice);
                succes = true;
            }

            return succes;
        }
    }
}
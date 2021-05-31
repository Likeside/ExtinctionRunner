using ExtinctionRunner.Models;
using UnityEngine;

namespace ExtinctionRunner.Controllers
{
    public static class PlayerSpriteManager
    {
        public static Track idle;
        public static Track jump;
        public static Track walk;
        public static bool predatorActive = false;

        public static int PredatorSkinPrice
        {
            get => 1000;
        } 

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
                predatorActive = true;
            }
        }

        public static void SetHerbiActive()
        {
            PlayerPrefs.SetInt("PredatorActive", 0);
            predatorActive = false;
        }

        public static bool BuyPredatorSkin()
        {
            bool succes = false;
            if (ScoreManager.TotalScore >= PredatorSkinPrice)
            {
                PlayerPrefs.SetInt("PredatorBought", 1);
                ScoreManager.RemoveScore(PredatorSkinPrice);
                succes = true;
            }

            return succes;
        }
    }
}
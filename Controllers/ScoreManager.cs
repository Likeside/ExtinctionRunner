using ExtinctionRunner.SavingGame;

namespace ExtinctionRunner.Controllers
{
    public static class ScoreManager
    {
        public static int CurrentScore { get; private set; }
        public static int TotalScore { get; private set; }
        public static void InitializeScore()
        {
            CurrentScore = 0;
            TotalScore = SaveSystem.LoadGame().score;
        }

        public static void AddScore(int score)
        {
            CurrentScore += score;

            if (CurrentScore%10  == 0)
            {
                AdsManager.ShowBannerAd();
            }

            if (CurrentScore % 10 == 3)
            {
                AdsManager.CloseBannerAd();
            }
        }

        public static void RemoveScore(int score)
        {
            TotalScore -= score;
        }
    }
}
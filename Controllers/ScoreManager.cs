using SavingGame;

namespace Controllers
{
    public static class ScoreManager
    {
        public static int CurrentScore { get; private set; }
        public static int TotalScore { get; private set; }
        public static int InitializeScore()
        {
            CurrentScore = 0;
            TotalScore = SaveSystem.LoadGame().score;
            return CurrentScore;
        }

        public static int AddScore(int score)
        {
            CurrentScore += score;

            if (CurrentScore%10  == 0)
            {
                AdsManager.ShowBannerAd();
            }

            if (CurrentScore % 10 == 2)
            {
                AdsManager.CloseBannerAd();
            }
            
            return CurrentScore;
        }

        public static int RemoveScore(int score)
        {
            TotalScore -= score;
            return TotalScore;
        }
    }
}
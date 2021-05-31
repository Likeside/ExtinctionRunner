using ExtinctionRunner.Controllers;

namespace ExtinctionRunner.SavingGame
{
    [System.Serializable]
    public class SavedData
    {
        public int score = 0;
        public bool adsDisabled;
        public bool redDinoSkinUnlocked;
        public int first = 0;
        public int second = 0;
        public int third = 0;
        public int fourth = 0;
        public int fifth = 0;


        public SavedData()
        {
            first += HighScoreManager.highScore[0];
            second += HighScoreManager.highScore[1];
            third += HighScoreManager.highScore[2];
            fourth += HighScoreManager.highScore[3];
            fifth += HighScoreManager.highScore[4];
            
            score += ScoreManager.CurrentScore + ScoreManager.TotalScore;
        }
    }
}
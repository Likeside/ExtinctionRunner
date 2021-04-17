using Controllers;

namespace SavingGame
{
    [System.Serializable]
    public class SavedData
    {
        public int score = 0;
        public bool adsDisabled;
        public bool redDinoSkinUnlocked;


        public SavedData()
        {
            score += ScoreManager.CurrentScore + ScoreManager.TotalScore;
        }
    }
}
using System.Collections.Generic;
using ExtinctionRunner.SavingGame;

namespace ExtinctionRunner.Controllers
{
    public static class HighScoreManager
    {
        public static List<int> highScore = new List<int>(){0, 0, 0, 0, 0};
        
        public static void SetHighScore(int score)
        {
            for (int i = 0; i < highScore.Count; i++)
            {
                if (score > highScore[i])
                {
                    highScore[highScore.Count -1] = score;
                    SortList();
                    break;
                } 
            }
        }

        private static void SortList()
        {
            for (int i = 0; i < highScore.Count; i++)
            {
                for (int j = i + 1; j < highScore.Count; j++)
                {
                    if (highScore[j] > highScore[i])
                    {
                        int temp = highScore[i];
                        highScore[i] = highScore[j];
                        highScore[j] = temp;
                    }
                }
            }
        }
        
        public static void InitializeHighScore()
        { 
            highScore[0] = SaveSystem.LoadGame().first;
          highScore[1] = SaveSystem.LoadGame().second;
          highScore[2] = SaveSystem.LoadGame().third;
          highScore[3] = SaveSystem.LoadGame().fourth;
          highScore[4] = SaveSystem.LoadGame().fifth;
        }
    }
}
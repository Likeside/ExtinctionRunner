using Controllers;
using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class SceneLoaderView: MonoBehaviour
    {
        public void LoadGameScene()
        {
            SceneLoader.LoadScene(SceneLoader.Scene.GameScene);
        }

        public void LoadMainMenu()
        {
            SceneLoader.LoadScene(SceneLoader.Scene.MainMenu);
        }

        public void LoadShop()
        {
            SceneLoader.LoadScene(SceneLoader.Scene.Shop);
        }

        public void LoadHighScore()
        {
            SceneLoader.LoadScene(SceneLoader.Scene.HighScore);
        }

        public void LoadLoading()
        {
            SceneLoader.LoadScene(SceneLoader.Scene.Loading);
        }
    }
}
using Controllers;
using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class SceneLoaderView: MonoBehaviour
    {
        public delegate void Click();

        public event Click OnClicked;
        public void LoadGameScene()
        {
            OnClicked?.Invoke();
            SceneLoader.LoadScene(SceneLoader.Scene.GameScene);
        }

        public void LoadMainMenu()
        {
            OnClicked?.Invoke();
            SceneLoader.LoadScene(SceneLoader.Scene.MainMenu);
        }

        public void LoadShop()
        {
            OnClicked?.Invoke();
            SceneLoader.LoadScene(SceneLoader.Scene.Shop);
        }

        public void LoadHighScore()
        {
            OnClicked?.Invoke();
            SceneLoader.LoadScene(SceneLoader.Scene.HighScore);
        }

        public void LoadLoading()
        {
            OnClicked?.Invoke();
            SceneLoader.LoadScene(SceneLoader.Scene.Loading);
        }

        public void QuitGame()
        {
            OnClicked?.Invoke();
            Application.Quit();
        }
    }
}
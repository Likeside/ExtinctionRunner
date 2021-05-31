using System;
using UnityEngine.SceneManagement;

namespace ExtinctionRunner.Controllers
{
    public static class SceneLoader
    {
        public enum Scene
        {
            MainMenu, 
            GameScene,
            Shop,
            HighScore,
            Loading
        }

        private static Action _onLoaderCallback;
        public static void LoadScene(Scene scene)
        {
            
            _onLoaderCallback = () =>
            {
                SceneManager.LoadScene(scene.ToString());
            };
            
            SceneManager.LoadScene(Scene.Loading.ToString());
        }

        public static void LoaderCallback()
        {
            if (_onLoaderCallback != null)
            {
                _onLoaderCallback();
                _onLoaderCallback = null;
            }
        }
       
    }
}
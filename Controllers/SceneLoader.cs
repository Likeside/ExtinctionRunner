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

        private static Action onLoaderCallback;
        public static void LoadScene(Scene scene)
        {
            
            onLoaderCallback = () =>
            {
                SceneManager.LoadScene(scene.ToString());
            };
            
            SceneManager.LoadScene(Scene.Loading.ToString());
        }

        public static void LoaderCallback()
        {
            if (onLoaderCallback != null)
            {
                onLoaderCallback();
                onLoaderCallback = null;
            }
        }
       
    }
}
using Controllers;
using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class LoaderCallback: MonoBehaviour
    {
        private bool isFirstUpdate = true;

        private void Update()
        {
            if (isFirstUpdate)
            {
                isFirstUpdate = false;
                SceneLoader.LoaderCallback();
            }
        }
    }
}
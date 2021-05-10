using Controllers;
using ExtinctionRunner.Interfaces;
using UnityEngine;

namespace Views
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
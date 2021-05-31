using Controllers;
using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class MenuItemClicker : MonoBehaviour
    {
        public void CLickSound()
        {
            AudioController.PlayClickSound();
        }

        private void Start()
        {
            AudioController.InitializeAudioController();
        }
    }
}
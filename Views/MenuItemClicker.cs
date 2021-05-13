using System;
using Controllers;
using UnityEngine;

namespace Views
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
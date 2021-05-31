using System;
using ExtinctionRunner;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Views;
using UnityEditor;
using UnityEngine;

namespace Controllers
{
    public static class AudioController
    {
        private static SoundsModel _soundsModel;
        private static AudioSource _globalAudioSource;
        private static bool isRunSoundPlaying = false;
     

        public static void InitializeAudioController()
        {
            _soundsModel = Resources.Load<SoundsModel>("SoundsModelSO");
            _globalAudioSource = GameObject.FindObjectOfType<GlobalAudioSourceView>().audioSource;
        }
        
        public static void PlayAsteroidCollisionSound(AudioSource audioSource)
        {
            audioSource.PlayOneShot(_soundsModel.asteroidCollision);
            
        }
        
        
        public static void PlayRunSound(AudioSource audioSource)
        {
            if (isRunSoundPlaying == false)
            {
                isRunSoundPlaying = true;
                audioSource.Play();
            }
        }

        public static void StopRunSound(AudioSource audioSource)
        {
            isRunSoundPlaying = false;
            audioSource.Stop();
        }

        public static void PlayJumpSound(AudioSource audioSource)
        {
            if (audioSource.isPlaying) {return;}
            else
            {
                audioSource.PlayOneShot(_soundsModel.jump);  
            }
            
            
        }

        public static void PlaySunkSound()
        {
            _globalAudioSource.PlayOneShot(_soundsModel.sunk);
        }

        public static void PlayDeadSound()
        {
            _globalAudioSource.PlayOneShot(_soundsModel.dead);
        }

        public static void PlayBonusSound()
        {
            _globalAudioSource.PlayOneShot(_soundsModel.bonusCollected);
            
        }

        public static void PlayClickSound()
        {
            _globalAudioSource.PlayOneShot(_soundsModel.menuItemClick);
        }

   

        
    }
}
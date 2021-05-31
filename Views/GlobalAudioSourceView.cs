using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class GlobalAudioSourceView: MonoBehaviour
    {
        [SerializeField] public AudioSource audioSource;

        private void Awake()
        {
           GlobalAudioSourceView[] objs = FindObjectsOfType<GlobalAudioSourceView>();

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }
            
            DontDestroyOnLoad(this);
        }
    }
}
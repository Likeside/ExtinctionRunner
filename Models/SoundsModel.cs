using UnityEngine;

namespace ExtinctionRunner
{
    [CreateAssetMenu(fileName = "SoundsModelSO", menuName = "Configs/SoundsModelSO", order = 3)]
    public class SoundsModel: ScriptableObject
    {
        public AudioClip asteroidCollision;
        public AudioClip bonusCollected;
        public AudioClip run;
        public AudioClip jump;
        public AudioClip menuItemClick;
        public AudioClip sunk;
        public AudioClip dead;
    }
}
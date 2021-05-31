using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class PlayerView: MonoBehaviour
    {
        [SerializeField] public AudioSource audioSource;
        [SerializeField] public AudioSource runAudioSource;
        public delegate void CollisionWithAsteroidHandler(float damage);
        public event CollisionWithAsteroidHandler OnAsteroidCollided;
        
        public void HandleCollisionWithAsteroid(float damage)
        {
            OnAsteroidCollided?.Invoke(damage);   
        }
        
    }
}
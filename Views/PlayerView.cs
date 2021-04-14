using ExtinctionRunner.Interfaces;
using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class PlayerView: MonoBehaviour
    {
        public delegate void CollisionWithAsteroidHandler(float damage);
        public event CollisionWithAsteroidHandler OnAsteroidCollided;
        
        public void HandleCollisionWithAsteroid(float damage)
        {
            OnAsteroidCollided?.Invoke(damage);   
        }
        
    }
}
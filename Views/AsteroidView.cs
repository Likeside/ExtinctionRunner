using System;
using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class AsteroidView: MonoBehaviour
    {
        public delegate void CollisionHandler(AsteroidView asteroidView, GameObject other);

        public event CollisionHandler OnCollisionHappened;
        public void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Collision happened");
            OnCollisionHappened?.Invoke(this, other.gameObject);
        }

        public void DestroyThis()
        {
            Destroy(this.gameObject);
        }
    }
}
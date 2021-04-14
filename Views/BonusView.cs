using ExtinctionRunner.Interfaces;
using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class BonusView: MonoBehaviour
    {
        [SerializeField] public BonusTypes bonusType;
        
        public delegate void CollisionHandler(BonusView bonusView, GameObject other);

        public event CollisionHandler OnCollisionHappened;
        public void OnTriggerEnter2D(Collider2D other)
        {
            OnCollisionHappened?.Invoke(this, other.gameObject);
        }

        public void ApplyEffect(IBonusEffect bonusEffect)
        {
            bonusEffect.ApplyEffect();
        }
        
        public void DestroyThis()
        {
            Destroy(this.gameObject);
        }
    }
}
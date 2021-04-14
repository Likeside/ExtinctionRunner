using ExtinctionRunner;
using ExtinctionRunner.Views;
using UnityEngine;

namespace Controllers
{
    public class PlayerHpController
    {
        private PlayerView _playerView;
        private HpModel _hpModel;

        public PlayerHpController(PlayerView playerView, HpModel hpModel)
        {
            _playerView = playerView;
            _hpModel = hpModel;
            _playerView.OnAsteroidCollided += ApplyDamage;
        }


        void ApplyDamage(float damage)
        {
            _hpModel.CurrentHealthPoints -= damage;
        }

        public void ApplyHealing(float hp)
        {
            _hpModel.CurrentHealthPoints += hp;
            
            Debug.Log(_hpModel.CurrentHealthPoints);
        }
        
        
        
    }
}
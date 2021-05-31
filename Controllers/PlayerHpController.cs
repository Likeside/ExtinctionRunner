using ExtinctionRunner.Models;
using ExtinctionRunner.Views;
using UnityEngine;

namespace ExtinctionRunner.Controllers
{
    public class PlayerHpController
    {
        private PlayerView _playerView;
        private HpModel _hpModel;
        private HealthBarSliderView _healthBarSliderView;

        public delegate void PlayerDead();

        public event PlayerDead OnPlayerDead;

        public PlayerHpController(PlayerView playerView, HpModel hpModel)
        {
            _playerView = playerView;
            _hpModel = hpModel;
            _playerView.OnAsteroidCollided += ApplyDamage;
            _healthBarSliderView = GameObject.FindObjectOfType<HealthBarSliderView>();
        }


        void ApplyDamage(float damage)
        {
            _hpModel.CurrentHealthPoints -= damage;
            _healthBarSliderView.slider.value = _hpModel.CurrentHealthPoints;

            if (_hpModel.CurrentHealthPoints <= 0)
            {
                OnPlayerDead?.Invoke();
            }
        }

        public void ApplyHealing(float hp)
        {
            if (_hpModel.CurrentHealthPoints < 100)
            {
                _hpModel.CurrentHealthPoints += hp;
                if (_hpModel.CurrentHealthPoints > 100)
                {
                    _hpModel.CurrentHealthPoints = 100;
                }
                _healthBarSliderView.slider.value = _hpModel.CurrentHealthPoints;
            }
        }
    }
}
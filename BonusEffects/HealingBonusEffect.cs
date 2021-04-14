using Controllers;
using ExtinctionRunner.Interfaces;

namespace BonusEffects
{
    public class HealingBonusEffect: IBonusEffect
    {
        private PlayerHpController _playerHpController;
        private float _hp;

        public HealingBonusEffect(PlayerHpController playerHpController, float hp)
        {
            _playerHpController = playerHpController;
            _hp = hp;
        }
        public void ApplyEffect()
        {
            _playerHpController.ApplyHealing(_hp);
        }
    }
}
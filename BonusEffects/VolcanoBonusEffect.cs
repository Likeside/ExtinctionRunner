using Controllers;
using ExtinctionRunner.Interfaces;
using UnityEngine;

namespace BonusEffects
{
    public class VolcanoBonusEffect: IBonusEffect
    {
        private int _scoreBonus;
        public VolcanoBonusEffect(int scoreBonus = 1)
        {
            _scoreBonus = scoreBonus;
        }
        public void ApplyEffect()
        {
            ScoreManager.AddScore(_scoreBonus);
            Debug.Log(ScoreManager.CurrentScore);
        }
    }
}
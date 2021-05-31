using Controllers;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Views;
using TMPro;
using UnityEngine;

namespace ExtinctionRunner.BonusEffects
{
    public class VolcanoBonusEffect: IBonusEffect
    {
        private int _scoreBonus;
        private TextMeshProUGUI _text;
        public VolcanoBonusEffect(int scoreBonus = 1)
        {
            _scoreBonus = scoreBonus;
            _text = GameObject.FindObjectOfType<VolcanoText>().text;
        }
        public void ApplyEffect()
        {
            ScoreManager.AddScore(_scoreBonus);
            _text.text = ScoreManager.CurrentScore.ToString();
            Debug.Log(ScoreManager.CurrentScore);
        }
    }
}
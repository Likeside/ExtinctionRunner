using ExtinctionRunner.Controllers;
using TMPro;
using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class PlayersCurrencyDisplay: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void Start()
        {
            _text.text = ScoreManager.TotalScore.ToString();
        }
    }
}
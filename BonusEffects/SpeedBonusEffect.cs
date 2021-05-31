using System.Collections.Generic;
using ExtinctionRunner.Controllers;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Views;
using UnityEngine;
using TMPro;

namespace ExtinctionRunner.BonusEffects
{
    public class SpeedBonusEffect: IBonusEffect, IExecutable
    {
        private float _speedMultiplier;
        private float _timer;
        private float _timerDefaultValue;
        private CoreController _coreController;
        private List<IExecutable> _listOfExecutables;
        private bool isActive = false;
        private TextMeshProUGUI _text;


        public SpeedBonusEffect(CoreController coreController, float speedMultiplier, float timer, List<IExecutable> _listOfExecutables)
        {
            _speedMultiplier = speedMultiplier;
            _timer = timer;
            _timerDefaultValue = _timer;
            _coreController = coreController;
            _listOfExecutables.Add(this);
            _text = GameObject.FindObjectOfType<SpeedText>().text;

        }
        public void ApplyEffect()
        {
            SpeedUp();
        }

        private void SpeedUp()
        {
            if (isActive)
            {
                _timer += _timerDefaultValue;
            }
            else
            {
                _coreController._rotationSpeed *= _speedMultiplier;
                isActive = true;
            }
            
        }
        private void SpeedDown()
        {
            _coreController._rotationSpeed /= _speedMultiplier;
            isActive = false;
        }
        

        public void Execute()
        {
            if (isActive)
            {
                _timer -= Time.deltaTime * 1;
                _text.text = _timer.ToString("n2");
            }

            if (_timer < 0)
            {
                SpeedDown();
                _text.text = "0";
                _timer = _timerDefaultValue;
            }
        }
    }
}
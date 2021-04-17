using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ExtinctionRunner;
using ExtinctionRunner.Interfaces;
using UnityEngine;

namespace BonusEffects
{
    public class SpeedBonusEffect: IBonusEffect, IExecutable
    {
        private float _speedMultiplier;
        private float _timer;
        private float _timerDefaultValue;
        private CoreController _coreController;
        private List<IExecutable> _listOfExecutables;
        private bool isActive = false;


        public SpeedBonusEffect(CoreController coreController, float speedMultiplier, float timer, List<IExecutable> _listOfExecutables)
        {
            _speedMultiplier = speedMultiplier;
            _timer = timer;
            _timerDefaultValue = _timer;
            _coreController = coreController;
            _listOfExecutables.Add(this);
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
                Debug.Log(_timer);
            }

            if (_timer < 0)
            {
                SpeedDown();
                _timer = _timerDefaultValue;
            }
        }
    }
}
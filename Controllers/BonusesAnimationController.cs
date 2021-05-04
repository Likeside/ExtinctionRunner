using System;
using System.Collections.Generic;
using ExtinctionRunner;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Views;
using UnityEngine;

namespace Controllers
{
    public class BonusesAnimationController: IExecutable, IDisposable
    {
        
        private List<BonusView> _bonusViews;
        private Dictionary<BonusTypes, Track> _tracks;
        private AnimationController _animationController;


        public BonusesAnimationController(AnimationController animationController)
        {
            _bonusViews = new List<BonusView>();
            _tracks = new Dictionary<BonusTypes, Track>()
            {
                {BonusTypes.Healing, Track.HealthBonusIdle},
                {BonusTypes.Speed, Track.SpeedBonusIdle},
                {BonusTypes.Volcano, Track.VolcanoBonusIdle}
            };
            _animationController = animationController;
        }
        
        public void Execute()
        {
            foreach (var bonusView in _bonusViews)
            {
                _animationController.StartAnimation(bonusView.spriteRenderer, _tracks[bonusView.bonusType], true, 30);
            }
        }

        public void AddToBonusAnimationController(BonusView bonusView)
        {
            _bonusViews.Add(bonusView);
            bonusView.OnCollisionHappened += RemoveFromBonusAnimationController;
        }

        private void RemoveFromBonusAnimationController(BonusView bonusView, GameObject other = null)
        {
            _bonusViews.Remove(bonusView);
        }

        public void Dispose()
        {
            foreach (var bonusView in _bonusViews)
            {
                bonusView.OnCollisionHappened -= RemoveFromBonusAnimationController;
            }
        }
    }
}
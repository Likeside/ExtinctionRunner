using System;
using System.Collections.Generic;
using ExtinctionRunner.BonusEffects;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Models;
using ExtinctionRunner.Views;
using UnityEngine;

namespace ExtinctionRunner.Controllers
{
    public class BonusesAnimationController: IExecutable, IDisposable, IBonusHandler
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

        public void AddBonusToHandler(BonusView bonusView)
        {
            _bonusViews.Add(bonusView);
            bonusView.OnCollisionHappened += RemoveFromBonusAnimationController;
        }

        private void RemoveFromBonusAnimationController(BonusView bonusView, GameObject other = null)
        {
            _bonusViews.Remove(bonusView);
            _animationController.StopAnimation(bonusView.spriteRenderer);
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
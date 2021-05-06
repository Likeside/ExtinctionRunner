using System;
using System.Collections.Generic;
using System.Linq;
using ExtinctionRunner;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Views;
using UnityEngine;

namespace Controllers
{
    public class BonusCollectedAnimationController: IBonusHandler, IDisposable
    {
        private Dictionary<BonusTypes, BonusDisplayView> _bonusDisplayViews;
        private List<BonusView> _bonusViews;
        private AnimationController _animationController;

        public BonusCollectedAnimationController(AnimationController animationController)
        {
            _bonusDisplayViews = new Dictionary<BonusTypes, BonusDisplayView>()
            {
                {BonusTypes.Healing, GameObject.FindObjectOfType<HealthBonusDisplayView>()},
                {BonusTypes.Speed, GameObject.FindObjectOfType<SpeedBonusDisplayView>()},
                {BonusTypes.Volcano, GameObject.FindObjectOfType<VolcanoBonusDisplayView>()}
            };
            
            _animationController = animationController;
            _bonusViews = new List<BonusView>();
        }

        public void AddBonusToHandler(BonusView bonusView)
        {
            bonusView.OnCollisionHappened += PlayBonusCollectedAnimation;
            _bonusViews.Add(bonusView);
        }

        private void PlayBonusCollectedAnimation(BonusView bonusView, GameObject other)
        {
            _animationController.StartAnimation(_bonusDisplayViews[bonusView.bonusType].Image, _bonusDisplayViews[bonusView.bonusType].Track, false, 30);
            bonusView.OnCollisionHappened -= PlayBonusCollectedAnimation;

        }

        public void Dispose()
        {
            foreach (var bonusView in _bonusViews)
            {
                bonusView.OnCollisionHappened -= PlayBonusCollectedAnimation;
            }
        }
    }
}
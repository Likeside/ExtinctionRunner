using System;
using System.Collections.Generic;
using BonusEffects;
using ExtinctionRunner;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Views;
using UnityEngine;

namespace Controllers
{
    public class BonusCollisionController
    {
        private Dictionary<BonusTypes, IBonusEffect> _bonusEffects;
        
        public BonusCollisionController(BonusesModel bonusesModel)
        {
            _bonusEffects = new Dictionary<BonusTypes, IBonusEffect>()
            {
                {BonusTypes.Healing, new HealingBonusEffect(bonusesModel._playerHpController, bonusesModel.HealHp)},
                {BonusTypes.Speed, new SpeedBonusEffect()},
                {BonusTypes.Volcano, new VolcanoBonusEffect()}
            };

        }

        void HandleCollision(BonusView bonusView, GameObject other)
        {
            bool isPlayer = other.TryGetComponent(out PlayerView playerView);
            if (isPlayer)
            {
                bonusView.ApplyEffect(_bonusEffects[bonusView.bonusType]);
                bonusView.OnCollisionHappened -= HandleCollision;
                bonusView.DestroyThis();
            }
        }

      public void AddBonusToHandler(GameObject bonus)
        {
            BonusView bonusView = bonus.GetComponent<BonusView>();
            bonusView.OnCollisionHappened += HandleCollision;
        }
        
    }
}
using System;
using System.Collections.Generic;
using BonusEffects;
using ExtinctionRunner;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Views;
using UnityEngine;

namespace Controllers
{
    public class BonusCollisionController: IBonusHandler
    {
        private Dictionary<BonusTypes, IBonusEffect> _bonusEffects;
        
        public BonusCollisionController(BonusesModel bonusesModel)
        {
            _bonusEffects = new Dictionary<BonusTypes, IBonusEffect>()
            {
                {BonusTypes.Healing, new HealingBonusEffect(bonusesModel.PlayerHpController, bonusesModel.HealHp)},
                {BonusTypes.Speed, new SpeedBonusEffect(bonusesModel.CoreController, bonusesModel.SpeedBonus, bonusesModel.Timer, bonusesModel.ListOFExecutables)},
                {BonusTypes.Volcano, new VolcanoBonusEffect()}
            };

        }

        void HandleCollision(BonusView bonusView, GameObject other)
        {
          //  bool isPlayer = other.TryGetComponent(out PlayerView playerView);
           // if (isPlayer)
          //  {
                bonusView.ApplyEffect(_bonusEffects[bonusView.bonusType]);
                bonusView.OnCollisionHappened -= HandleCollision;
                bonusView.DestroyThis();
           // }
        }

      public void AddBonusToHandler(BonusView bonusView)
        {
            bonusView.OnCollisionHappened += HandleCollision;
        }
        
    }
}
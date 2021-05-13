using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Views;
using UnityEngine;

namespace Controllers
{
    public class BonusesHandler: IBonusHandler
    {
        private BonusCollisionController _bonusCollisionController;
        private BonusesAnimationController _bonusesAnimationController;
        private BonusCollectedAnimationController _bonusCollectedAnimationController;
       

        public BonusesHandler(BonusCollisionController bonusCollisionController, BonusesAnimationController bonusesAnimationController, BonusCollectedAnimationController bonusCollectedAnimationController)
        {
            _bonusCollisionController = bonusCollisionController;
            _bonusesAnimationController = bonusesAnimationController;
            _bonusCollectedAnimationController = bonusCollectedAnimationController;
           
        }

        public void AddBonusToHandler(BonusView bonusView)
        {
            _bonusCollisionController.AddBonusToHandler(bonusView);
            _bonusesAnimationController.AddBonusToHandler(bonusView);
            _bonusCollectedAnimationController.AddBonusToHandler(bonusView);
     
        }
        
        
    }
}
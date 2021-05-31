using ExtinctionRunner.Controllers;
using ExtinctionRunner.Models;
using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class SetSkinActiveButton: MonoBehaviour
    {
        [SerializeField] private ShopController _shopController;
        
        public void ToggleSkin()
        {
            if (PlayerSpriteManager.predatorActive)
            {
                PlayerSpriteManager.SetHerbiActive();
                _shopController.animationController.StartAnimation(_shopController.playerImage, Track.WalkPredator, true, 30);
            }
            else
            {
                PlayerSpriteManager.SetPredatorActive();
                _shopController.animationController.StartAnimation(_shopController.playerImage, Track.Walk, true, 30);
            }
        }
    }
}
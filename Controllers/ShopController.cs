using System;
using ExtinctionRunner;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class ShopController: MonoBehaviour
    {
        [SerializeField] private Image _playerImage;
        private AnimationController _animationController;
        
        
       private void Start()
       {
           AnimationModelSO config = Resources.Load<AnimationModelSO>("DinoAnimation");
           _animationController = new AnimationController(config);
           _animationController.StartAnimation(_playerImage, Track.WalkPredator, true, 30);
       }


       private void Update()
       {
           _animationController.Execute();
       }
    }
}
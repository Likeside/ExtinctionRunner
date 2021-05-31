using ExtinctionRunner.Models;
using UnityEngine;
using UnityEngine.UI;

namespace ExtinctionRunner.Controllers
{
    public class ShopController: MonoBehaviour
    {
        [SerializeField] public Image playerImage;
        public AnimationController animationController;
        
        
       private void Start()
       {
           AnimationModelSO config = Resources.Load<AnimationModelSO>("DinoAnimation");
           animationController = new AnimationController(config);
           animationController.StartAnimation(playerImage, Track.WalkPredator, true, 30);
       }
       
       private void Update()
       {
           animationController.Execute();
       }
    }
}
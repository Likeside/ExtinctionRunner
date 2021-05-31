using System.Collections.Generic;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Models;
using ExtinctionRunner.Views;
using UnityEngine;

namespace ExtinctionRunner.Controllers
{
    public class GameController: MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _jumpForce;

        [SerializeField] private CoreView _coreView;
        [SerializeField] private float _rotationSpeed;


        [SerializeField] private LayerMask _groundCheckLayerMask;
        [SerializeField] private LayerMask _waterCheckLayerMask;
        
        [SerializeField] private float _asteroidsSpawnRadius;

        [SerializeField] private Transform _meteoritesTarget;

        
        [SerializeField] private float _playerMaxHp;
        [SerializeField] private float _healingHealHp;


        [SerializeField] private float _speedBonus;
        [SerializeField] private float _timerForSpeedBonus;

        [SerializeField] private Disposer _disposer; //ДОБАВИТЬ СЮДА ВСЕ ДИСПОУЗАБЛЫ, ВЫЗЫВАТЬ ПРИ НАЖАТИИ КНОПКИ QUIT
        
        private List<IExecutable> _listOfExecutables = new List<IExecutable>();
        private List<IFixedExecutable> _listOfFixedExecutables = new List<IFixedExecutable>();

        private void Start()
        {
            AudioController.InitializeAudioController();
            AdsManager.InitializeAdsManager();
            PlayerSpriteManager.Initialize();
            
            InputController inputController = FindObjectOfType<UiInputView>()._inputController;
            _listOfExecutables.Add(inputController);
            _listOfFixedExecutables.Add(inputController);
            
            AnimationModelSO config = Resources.Load<AnimationModelSO>("DinoAnimation");
            AnimationController animationController = new AnimationController(config);
            BonusesAnimationController bonusesAnimationController = new BonusesAnimationController(animationController);
            _listOfExecutables.Add(bonusesAnimationController);
            BonusCollectedAnimationController bonusCollectedAnimationController =
                new BonusCollectedAnimationController(animationController); 
            
            
            PlayerController playerController = new PlayerController(_playerView, animationController, inputController, _groundCheckLayerMask, _waterCheckLayerMask, _jumpForce);
            _listOfExecutables.Add(playerController);
           
            CoreController coreController = new CoreController(_coreView, inputController, _rotationSpeed);


            HpModel hpModel = new HpModel(_playerMaxHp);
            PlayerHpController playerHpController = new PlayerHpController(_playerView, hpModel);

        
            
            
            BonusesModel bonusesModel = new BonusesModel(playerHpController, _healingHealHp, coreController, _speedBonus, _timerForSpeedBonus, _listOfExecutables);
            
            BonusCollisionController bonusCollisionController = new BonusCollisionController(bonusesModel);

            BonusesHandler bonusesHandler = new BonusesHandler(bonusCollisionController, bonusesAnimationController,
                bonusCollectedAnimationController);
            
            AsteroidsController asteroidsController = new AsteroidsController(_meteoritesTarget, _asteroidsSpawnRadius, bonusesHandler);
            _listOfExecutables.Add(asteroidsController);
            _listOfFixedExecutables.Add(asteroidsController);

            GameOverController gameOverController =
                new GameOverController(playerController, playerHpController, inputController, asteroidsController);
            
            _disposer.AddToDisposableList(animationController);
            _disposer.AddToDisposableList(bonusCollectedAnimationController);
            _disposer.AddToDisposableList(bonusesAnimationController);
            _disposer.AddToDisposableList(playerController);
        }
        
        void Update()
        {
            foreach (var executable in _listOfExecutables)
            {
                executable.Execute();
            }
        }

        private void FixedUpdate()
        {
            foreach (var fixedExecutable in _listOfFixedExecutables)
            {
                fixedExecutable.IFixedExecute();
            }
        }
    }
}
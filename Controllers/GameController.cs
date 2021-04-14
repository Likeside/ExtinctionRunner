using System;
using System.Collections.Generic;
using Controllers;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Views;
using UnityEngine;

namespace ExtinctionRunner
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
        
        
        
        private List<IExecutable> _listOfExecutables = new List<IExecutable>();
        private List<IFixedExecutable> _listOfFixedExecutables = new List<IFixedExecutable>();
        private List<IStartable> _listOfStartables = new List<IStartable>();

        private void Start()
        {
            InputController inputController = new InputController();
            _listOfExecutables.Add(inputController);
            
            PlayerController playerController = new PlayerController(_playerView, inputController, _groundCheckLayerMask, _waterCheckLayerMask, _jumpForce);
            _listOfExecutables.Add(playerController);
           
            CoreController coreController = new CoreController(_coreView, inputController, _rotationSpeed);


            HpModel hpModel = new HpModel(_playerMaxHp);
            PlayerHpController playerHpController = new PlayerHpController(_playerView, hpModel);
            BonusesModel bonusesModel = new BonusesModel(playerHpController, _healingHealHp);
            
            BonusCollisionController bonusCollisionController = new BonusCollisionController(bonusesModel);
            
            AsteroidsController asteroidsController = new AsteroidsController(_meteoritesTarget, _asteroidsSpawnRadius, bonusCollisionController);
            _listOfExecutables.Add(asteroidsController);
            _listOfFixedExecutables.Add(asteroidsController);
            _listOfStartables.Add(asteroidsController);



            foreach (var startable in _listOfStartables)
            {
                startable.OnStart();
                
            }
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
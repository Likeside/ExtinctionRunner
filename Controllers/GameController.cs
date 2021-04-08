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

      
        [SerializeField] private int _asteroidsMaxAmount;
        [SerializeField] private float _asteroidsSpawnRate;

        private List<IExecutable> _listOfExecutables = new List<IExecutable>();
        private List<IStartable> _listOfStartables = new List<IStartable>();

        private void Start()
        {
            InputController inputController = new InputController();
            _listOfExecutables.Add(inputController);
            
            PlayerController playerController = new PlayerController(_playerView, inputController, _groundCheckLayerMask, _waterCheckLayerMask, _jumpForce);
            _listOfExecutables.Add(playerController);
           
            CoreController coreController = new CoreController(_coreView, inputController, _rotationSpeed);

            AsteroidsController asteroidsController = new AsteroidsController(_asteroidsMaxAmount, _asteroidsSpawnRate);
            _listOfExecutables.Add(asteroidsController);
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
    }
}
using System;
using System.Collections.Generic;
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
        private List<IExecutable> _listOfExecutables = new List<IExecutable>();

        private void Start()
        {
            PlayerController playerController = new PlayerController(_playerView, _jumpForce);
            _listOfExecutables.Add(playerController);
            
            
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
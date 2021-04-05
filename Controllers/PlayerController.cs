using System;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Views;
using UnityEngine;

namespace ExtinctionRunner
{
    public class PlayerController: IExecutable, IDisposable
    {
        private PlayerView _playerView;
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private InputController _inputController;
        private AnimationController _animationController;
        private float _jumpForce;
    
        public PlayerController(PlayerView playerView, float jumpForce)
        {
            _playerView = playerView;
            _spriteRenderer = _playerView.GetComponentInParent<SpriteRenderer>();
            _rigidbody2D = _playerView.GetComponentInParent<Rigidbody2D>();
            _jumpForce = jumpForce;
            _inputController = new InputController();
            AnimationModelSO config = Resources.Load<AnimationModelSO>("DinoAnimation");
            _animationController = new AnimationController(config);
            _inputController.OnArrowPressed += Move;
            _inputController.OnJumpButtonPressed += Jump;

        }


        private void Move(float axis)
        {
            if (axis != 0)
            {
                _animationController.StartAnimation(_spriteRenderer, Track.Walk, true, 30);
            }
            else
            {
                _animationController.StartAnimation(_spriteRenderer, Track.Idle, true, 30);
            }

            if (axis > 0)
            {
                _spriteRenderer.flipX = true;
            }

            if (axis < 0)
            {
                _spriteRenderer.flipX = false;
            }
        }

        private void Jump()
        {
            _animationController.StartAnimation(_spriteRenderer, Track.Jump, false, 30);
            _rigidbody2D.MovePosition(Vector2.up*_jumpForce);
        } 
        
        public void Execute()
        {
            _animationController.Execute();
            _inputController.Execute();
            
        }

        public void Dispose()
        {
            _inputController.OnArrowPressed -= Move;
            _inputController.OnJumpButtonPressed -= Jump;

        }
    }
}
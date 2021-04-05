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
        private bool isJumping = false;
    
        public PlayerController(PlayerView playerView, InputController inputController, float jumpForce)
        {
            _playerView = playerView;
            _spriteRenderer = _playerView.GetComponentInParent<SpriteRenderer>();
            _rigidbody2D = _playerView.GetComponentInParent<Rigidbody2D>();
            _jumpForce = jumpForce;
            _inputController = inputController;
            AnimationModelSO config = Resources.Load<AnimationModelSO>("DinoAnimation");
            _animationController = new AnimationController(config);
            _inputController.OnArrowPressed += Move;
            _inputController.OnJumpButtonPressed += Jump;

        }


        private void Move(float axis)
        {
            if (axis != 0)
            {
                if (isJumping == false)
                {
                    _animationController.StartAnimation(_spriteRenderer, Track.Walk, true, 30);
                }
            }
            else
            {
                if (isJumping == false)
                {
                    _animationController.StartAnimation(_spriteRenderer, Track.Idle, true, 30);
                }
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
            isJumping = true;
            _animationController.StartAnimation(_spriteRenderer, Track.Jump, false, 30); //добавить граундчек
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
           // isJumping = false;
        } 
        
        public void Execute()
        {
            _animationController.Execute();
        }

        public void Dispose()
        {
            _inputController.OnArrowPressed -= Move;
            _inputController.OnJumpButtonPressed -= Jump;

        }
    }
}
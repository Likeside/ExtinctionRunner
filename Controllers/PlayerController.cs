using System;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Views;
using UnityEngine;

namespace ExtinctionRunner.Controllers
{
    public class PlayerController: IExecutable, IDisposable
    {
        public PlayerView _playerView;
        private Transform _playerTransform;
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private InputController _inputController;
        private AnimationController _animationController;
        private GroundCheckController _playerGroundCheckController;
        private GroundCheckController _playerWaterCheckController;
        private float _jumpForce;
        private Vector3 _scaleVector1;
        private Vector3 _scaleVector2;

        public delegate void PlayerSunk();
        public event PlayerSunk OnPlayerSunk;

        public PlayerController(PlayerView playerView, AnimationController animationController, InputController inputController, LayerMask groundCheckLayerMask, LayerMask waterCheckLayerMask, float jumpForce)
        {
            _playerView = playerView;
            _playerTransform = _playerView.GetComponent<Transform>();
            _spriteRenderer = _playerView.GetComponentInParent<SpriteRenderer>();
            _rigidbody2D = _playerView.GetComponentInParent<Rigidbody2D>();
            _jumpForce = jumpForce;
            _inputController = inputController;
            _playerWaterCheckController =
                new GroundCheckController(waterCheckLayerMask, _playerView.GetComponent<Collider2D>(), 0.5f);
            _playerGroundCheckController =
                new GroundCheckController(groundCheckLayerMask, _playerView.GetComponent<Collider2D>(), 0.01f);
            _animationController = animationController;
            _inputController.OnArrowPressed += Move;
            _inputController.OnJumpButtonPressed += Jump;

            _scaleVector1 = new Vector3(-1f, 1f, 1f);
            _scaleVector2 = new Vector3(1f, 1f, 1f);

        }

        private void Move(float axis)
        {
            if (_playerGroundCheckController.IsGrounded())
            {
                if (axis != 0)
                {
                    AudioController.PlayRunSound(_playerView.runAudioSource);
                    _animationController.StartAnimation(_spriteRenderer, PlayerSpriteManager.walk, true, 30);
                }
                else
                {
                    AudioController.StopRunSound(_playerView.runAudioSource);
                    _animationController.StartAnimation(_spriteRenderer, PlayerSpriteManager.idle, true, 30);
                }
            }
            else
            {
                AudioController.StopRunSound(_playerView.runAudioSource);
            }

            if (axis > 0)
            {
                _playerTransform.localScale = _scaleVector1;
            }

            if (axis < 0)
            {
                _playerTransform.localScale = _scaleVector2;
            }

            if (_playerWaterCheckController.IsGrounded())
            {
                AudioController.PlaySunkSound();
                OnPlayerSunk?.Invoke();
            }
        }

        private void Jump()
        { 
            if (_playerGroundCheckController.IsGrounded())
            {
                AudioController.PlayJumpSound(_playerView.audioSource);
               _rigidbody2D.AddForce(Vector2.up * _jumpForce);
               _animationController.StartAnimation(_spriteRenderer, PlayerSpriteManager.jump, false, 30);
            }
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
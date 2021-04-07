using System;
using ExtinctionRunner.Interfaces;
using ExtinctionRunner.Views;
using PlatformerMVC;
using UnityEngine;

namespace ExtinctionRunner
{
    public class PlayerController: IExecutable, IDisposable
    {
        private PlayerView _playerView;
        private Transform _playerTransform;
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private InputController _inputController;
        private AnimationController _animationController;
        private GroundCheckController _playerGroundCheckController;
        private GroundCheckController _playerWaterCheckController;
        private float _jumpForce;


        public PlayerController(PlayerView playerView, InputController inputController, LayerMask groundCheckLayerMask, LayerMask waterCheckLayerMask, float jumpForce)
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
            AnimationModelSO config = Resources.Load<AnimationModelSO>("DinoAnimation");
            _animationController = new AnimationController(config);
            _inputController.OnArrowPressed += Move;
            _inputController.OnJumpButtonPressed += Jump;

        }


        private void Move(float axis)
        {
            if (_playerGroundCheckController.IsGrounded())
            {
                if (axis != 0)
                {
                    _animationController.StartAnimation(_spriteRenderer, Track.Walk, true, 30);
                }
                else
                {
                    _animationController.StartAnimation(_spriteRenderer, Track.Idle, true, 30);
                }
            }
            else
            {
                _animationController.StartAnimation(_spriteRenderer, Track.Jump, false, 30);
            }

            if (axis > 0)
            {
                _playerTransform.localScale = new Vector3(-1f, 1f, 1f);
            }

            if (axis < 0)
            {
                _playerTransform.localScale = new Vector3(1f, 1f, 1f);
            }

            if (_playerWaterCheckController.IsGrounded())
            {
                Debug.Log("Sunk");
            }
        }

        private void Jump()
        { 
            if (_playerGroundCheckController.IsGrounded())
            {
               _rigidbody2D.AddForce(Vector2.up * _jumpForce);
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
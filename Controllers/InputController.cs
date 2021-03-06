using ExtinctionRunner.Interfaces;
using UnityEngine;

namespace ExtinctionRunner.Controllers
{
    public class InputController: IExecutable, IFixedExecutable
    {
        public bool movementEnabled = true;
        public delegate void MovementHandler(float axis);
        public event MovementHandler OnArrowPressed;

        public delegate void JumpHandler();
        public event JumpHandler OnJumpButtonPressed;

        public float horizontalAxis = 0;
        public bool jumpPressed = false;

        private float jumpPressedTimerDefault = 0.2f;
        private float jumpPressedTimer = 0f;
        public void Execute()
        {
            if (movementEnabled)
            {
                OnArrowPressed?.Invoke(horizontalAxis);

                jumpPressedTimer -= Time.deltaTime * 1;
                if (
                    jumpPressed) 
                {
                    jumpPressedTimer = jumpPressedTimerDefault;
                }
            }
        }

        public void IFixedExecute()
        {
            if (movementEnabled)
            {
                if (jumpPressedTimer > 0)
                {
                    OnJumpButtonPressed?.Invoke();
                }
                else
                {
                    jumpPressed = false;
                }
            }
        }
    }
}
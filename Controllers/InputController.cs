using ExtinctionRunner.Interfaces;
using UnityEngine;

namespace ExtinctionRunner
{
    public class InputController: IExecutable
    {
        public delegate void MovementHandler(float axis);
        public event MovementHandler OnArrowPressed;

        public delegate void JumpHandler();
        public event JumpHandler OnJumpButtonPressed;
        public void Execute()
        {
            var horizontalAxis = Input.GetAxis("Horizontal");
            OnArrowPressed?.Invoke(horizontalAxis);

            if (Input.GetButtonDown("Fire1"))
            {
                OnJumpButtonPressed?.Invoke();
            }
        }
    }
}
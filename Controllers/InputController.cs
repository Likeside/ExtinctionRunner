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

        public float horizontalAxis = 0;
        public bool jumpPressed = false;
        public void Execute()
        {
            //horizontalAxis = Input.GetAxis("Horizontal");
            OnArrowPressed?.Invoke(horizontalAxis);

            if (jumpPressed) //Linux machine returns "O" when spacebar is pressed, need to fix in preferences before build
            {
                OnJumpButtonPressed?.Invoke();
                jumpPressed = false;
            }
        }
    }
}
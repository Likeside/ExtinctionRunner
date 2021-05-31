using ExtinctionRunner.Controllers;
using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class UiInputView: MonoBehaviour
    {
        //Вывести контроллер в отдельную вьюшку, кнопки разбить по разным
       public InputController _inputController = new InputController();

       public void InputAxis(float axis)
       {
           _inputController.horizontalAxis = axis;
       }

      public void InputJump(bool jumpPressed)
       {
           _inputController.jumpPressed = jumpPressed;
       }
    }
}
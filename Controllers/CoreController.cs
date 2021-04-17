using System;
using ExtinctionRunner.Views;
using UnityEngine;

namespace ExtinctionRunner
{
    public class CoreController: IDisposable
    {
        private CoreView _coreView;
        private InputController _inputController;
        private float _rotationSpeed;
        private Vector3 _rotationAxis = new Vector3(0, 0, 1);

        public CoreController(CoreView coreView, InputController inputController, float rotationSpeed)
        {
            _coreView = coreView;
            _inputController = inputController;
            _rotationSpeed = rotationSpeed;

            _inputController.OnArrowPressed += Rotate;
        }

       private void Rotate(float axis)
        {
            if (axis > 0)
            {
                _coreView.transform.Rotate(_rotationAxis, _rotationSpeed*Time.deltaTime);
            }

            if (axis < 0)
            {
               _coreView.transform.Rotate(_rotationAxis, -(_rotationSpeed*Time.deltaTime));
            }
        }

        public void Dispose()
        {
            _inputController.OnArrowPressed -= Rotate;
        }
    }
}
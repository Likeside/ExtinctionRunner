using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class Disposer: MonoBehaviour
    {
        private List<IDisposable> _disposables;

        private void Start()
        {
            _disposables = new List<IDisposable>();
        }

        public void AddToDisposableList(IDisposable disposable)
        {
            _disposables.Add(disposable);
        }

        public void DisposeEverything()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
using UnityEngine;

namespace ExtinctionRunner.Views
{
    public class PanelCloseButton: MonoBehaviour
    {
        [SerializeField] private GameObject _panel;

        public void ClosePanel()
        {
            _panel.SetActive(false);
        }
    }
}
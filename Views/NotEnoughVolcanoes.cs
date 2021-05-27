using UnityEngine;

namespace Views
{
    public class NotEnoughVolcanoes: MonoBehaviour
    {
        [SerializeField] private GameObject _notEnoughVolcanoesPanel;

        public void ClosePanel()
        {
            _notEnoughVolcanoesPanel.SetActive(false);
        }
    }
}
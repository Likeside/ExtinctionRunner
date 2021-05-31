using UnityEngine;
using UnityEngine.UI;

namespace ExtinctionRunner.Views
{
    public class PressedButtonImageView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Sprite[] _sprites;

        public void SetImage(int index)
        {
            _image.sprite = _sprites[index];
        }
    }
}

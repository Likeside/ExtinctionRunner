using ExtinctionRunner.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace ExtinctionRunner.Views
{
    public class SpeedBonusDisplayView: MonoBehaviour, IBonusDisplayView
    {
        [SerializeField] private Track _track;
        [SerializeField] private Image _image;

        public Track Track
        {
            get => _track;
            set { _track = value; }
        }

        public Image Image
        {
            get => _image;
            set { _image = value; }
        }
    }
}
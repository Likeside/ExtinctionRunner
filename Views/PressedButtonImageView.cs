using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressedButtonImageView : MonoBehaviour
{
  [SerializeField] private Image _image;
  [SerializeField] private Sprite[] _sprites;

 public void SetImage(int index)
  {
      _image.sprite = _sprites[index];
  }
}

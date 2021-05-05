using UnityEngine;
using UnityEngine.UI;

namespace ExtinctionRunner.Interfaces
{
    public interface IBonusDisplayView
    {
        Track Track { get; set; }
        Image Image { get; set; }
    }
}
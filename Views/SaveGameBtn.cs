using System.Collections;
using System.Collections.Generic;
using SavingGame;
using UnityEngine;

public class SaveGameBtn : MonoBehaviour
{
   public void SaveGame()
    {
        SaveSystem.SaveGame();
    }
}

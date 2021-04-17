

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Controllers;
using UnityEngine;

namespace SavingGame
{
    public class SaveSystem
    {
        private static string _path = Application.persistentDataPath + "/saveddata.sd";
        public static void SaveGame()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_path, FileMode.Create);

            SavedData savedData = new SavedData();
            
            formatter.Serialize(stream, savedData);
            stream.Close();
        }

        public static SavedData LoadGame()
        {
            if (File.Exists(_path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(_path, FileMode.Open);
                SavedData savedData = formatter.Deserialize(stream) as SavedData;
                stream.Close();
                Debug.Log(savedData.score);
                return savedData;
            }
            else
            {
                SaveGame();
                return LoadGame();
            }
        }
    }
}
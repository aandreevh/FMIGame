using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace UIController
{
    public static class SaveManager
    {
        private const string saveName = "/gamesave.sv";
        public static void CreateSaveGame(List<LevelScene> levelScenes)
        {
            string path = Application.persistentDataPath + saveName;
            if (!File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Create);

                SaveData saveData = new SaveData(levelScenes);
                formatter.Serialize(stream, saveData);
                stream.Close();
            }
        }

        public static void SaveGame(List<LevelState> levelStates)
        {
            string path = Application.persistentDataPath + saveName;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            
            SaveData saveData = new SaveData(levelStates);
            formatter.Serialize(stream, saveData);
            stream.Close();
        }

        public static SaveData LoadGame()
        {
            string path = Application.persistentDataPath + saveName;
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
                SaveData saveData = formatter.Deserialize(stream) as SaveData;
                stream.Close();

                return saveData;
            }
            else
            {
                return null;
            }
        }
        
    }
}
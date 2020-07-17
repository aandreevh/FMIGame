using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Global.Level;
using UnityEngine;

namespace Global
{
    public static class SaveManager
    {
        private const string SaveName = "savegame.sv";
        public static string SavePath => Application.persistentDataPath +
                                         Path.DirectorySeparatorChar + SaveName;
        public static void CreateSaveGame(List<LevelScene> levelScenes)
        {
            using (var saveStream = OpenSaveFileStream(FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                var saveData = new SaveData(levelScenes);
                formatter.Serialize(saveStream,saveData);
            }
        }
        
        public static void SaveGame(List<LevelState> levelStates)
        {
            using (var saveStream = OpenSaveFileStream(FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                var saveData = new SaveData(levelStates);
                formatter.Serialize(saveStream, saveData);   
            }
        }
        
        public static SaveData LoadGame()
        {
            using (var saveStream = OpenSaveFileStream(FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                return formatter.Deserialize(saveStream) as SaveData;
            }
        }

        private static FileStream OpenSaveFileStream(FileMode mode)
        {
            var stream = new FileStream(SavePath, mode);
            return stream;
        }
    }
}
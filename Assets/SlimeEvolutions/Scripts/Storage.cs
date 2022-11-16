using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace asd
{
    public class Storage
    {
        private string filePath;
        private string directory;

        public Storage()
        {
            directory = Application.persistentDataPath + "/Saves";
            filePath = directory + "/GameSave.json";
        }

        public DataStruct Load(DataStruct saveDataByDefault)
        {
            if (!File.Exists(filePath))
            {
                Save(saveDataByDefault);
                return saveDataByDefault;
            }
            DataStruct savedData = JsonConvert.DeserializeObject<DataStruct>(File.ReadAllText(filePath));
            return savedData;
        }

        public void Save(DataStruct saveData)
        {
            Directory.CreateDirectory(directory);
            string jsonData = JsonConvert.SerializeObject(saveData, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            File.WriteAllText(filePath, jsonData);
        }
    }
}

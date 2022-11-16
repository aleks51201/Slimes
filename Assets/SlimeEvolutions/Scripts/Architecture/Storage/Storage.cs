using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace SlimeEvolutions.Architecture
{
    public class Storage
    {
        private string filePath;
        private string directory;

        public Storage()
        {
            directory = Application.persistentDataPath + "/Saves";
            Directory.CreateDirectory(directory);
            filePath = directory + "/GameSave.json";
        }

        public DataStruct Load()
        {
            if (!File.Exists(filePath))
            {
                DataStruct dataStructHolder = new()
                {
                    InventorySlimes = new(),
                    LastDateTime = new(),
                    LaboratoryData = new()
                };
                Save(dataStructHolder);
                return dataStructHolder;
            }
            return JsonConvert.DeserializeObject<DataStruct>(File.ReadAllText(filePath));
        }

        public void Save(DataStruct data)
        {
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            File.WriteAllText(filePath, jsonData);
        }
    }
}

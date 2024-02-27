using System.IO;
using Sadalmelik.FitApp.Architecture;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace Sadalmelik.FitApp.Main
{
    public class SaveSystem : SingletonMonoBehaviour<SaveSystem>
    {
        private string _saveFilePath;

        public ApplicationData Data { get; private set; }
        
        protected override void Init()
        {
            _saveFilePath = Path.Combine(Application.persistentDataPath, "save", "data.json");
            
            if (!File.Exists(_saveFilePath))
            {
                Data = new ApplicationData();
            }
            else
            {
                var rawData = File.ReadAllText(_saveFilePath);
                Data = JsonConvert.DeserializeObject<ApplicationData>(rawData);
            }
        }

        public void Save()
        {
            var rawData = JsonConvert.SerializeObject(Data);
            File.WriteAllText(_saveFilePath, rawData);
        }
    }
}
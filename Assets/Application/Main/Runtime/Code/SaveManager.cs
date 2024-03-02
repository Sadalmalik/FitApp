using System.Diagnostics;
using System.IO;
using Sadalmelik.FitApp.Architecture;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Sadalmelik.FitApp.Main
{
    public class SaveManager : SharedObject
    {
        public const string SaveFolder = "save";
        
        private string _saveDirectoryPath;
        private string _saveFilePath;

        public ApplicationData Data { get; private set; }
        
        public override void Init()
        {
            _saveDirectoryPath = Path.Combine(Application.persistentDataPath, SaveFolder);

            if (!Directory.Exists(_saveDirectoryPath))
                Directory.CreateDirectory(_saveDirectoryPath);
            
            _saveFilePath = Path.Combine(_saveDirectoryPath, "data.json");
            
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

#if UNITY_EDITOR
        [MenuItem("[FitApp]/Open Save Folder")]
        private static void OpenSaveFolder()
        {
            var path = Path.GetFullPath(Path.Combine(Application.persistentDataPath, SaveFolder));
            
            if (Directory.Exists(path))
            {
                Process.Start(new ProcessStartInfo
                {
                    Arguments = $"\"{path}\"",
                    FileName = "explorer.exe"
                });
            }
            else
            {
                Debug.LogWarning($"Folder '{path}' not exists!");
            }
        }
#endif
    }
}
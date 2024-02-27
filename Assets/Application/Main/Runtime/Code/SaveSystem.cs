using System;
using System.IO;
using Sadalmelik.FitApp.Architecture;
using UnityEngine;

namespace Sadalmelik.FitApp.Main
{
    [Serializable]
    public class SaveData
    {
        
    }
    public class SaveSystem : SingletonMonoBehaviour<SaveSystem>
    {
        private string _saveFilePath;

        public SaveData Data { get; private set; }
        
        protected override void Init()
        {
            _saveFilePath = Path.Combine(Application.persistentDataPath, "save", "data.json");
            if (!File.Exists(_saveFilePath))
            {
                Data = new SaveData();
            }
            else
            {
                // Data = Newton
            }
        }
    }
}
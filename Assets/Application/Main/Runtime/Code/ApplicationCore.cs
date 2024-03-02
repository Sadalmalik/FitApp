using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using Sadalmelik.FitApp.Architecture;

namespace Sadalmelik.FitApp.Main
{
    public class ApplicationCore : SharedObject
    {
        [Inject] private SaveManager _saveManager;
        
        public ApplicationConfig Config { get; private set; }

        public List<FoodEntry> FoodList { get; private set; }

        private event Action OnDataLoaded;
        
        public void SubscribeLoaded(Action callback)
        {
            if (FoodList == null)
                OnDataLoaded += callback;
            else
                callback?.Invoke();
        }
        
        public override void Init()
        {
            Config = ApplicationConfig.Instance;
            
            DownloadDatabase();
        }

        private async void DownloadDatabase()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            WebClient client = new WebClient();

            Stream data = client.OpenRead(Config.DatabaseSource);
            StreamReader reader = new StreamReader(data);
            string content = await reader.ReadToEndAsync();

            FoodList = ObjectCSVConverter.FromCSV<FoodEntry>(content);
            watch.Stop();
            
            OnDataLoaded?.Invoke();
        }

        public void AddFoodToDiary(FoodEntry foodEntry)
        {
            var diary = _saveManager.Data.FoodDiary;
            diary.Add(new FoodDiaryEntry
            {
                id = diary.Count,
                date = DateTime.Now,
                foodId = foodEntry.Id,
                calories = foodEntry.calories
            });
            _saveManager.Save();
        }
        
        public float GetRecommendedCalories()
        {
            if (_saveManager
                    .Data
                    .UserData
                    .UserSex == UserSex.Male)
            {
                return Config.harrisBenedictMale.Calculate(_saveManager.Data.UserData);
            }
            return Config.harrisBenedictFemale.Calculate(_saveManager.Data.UserData);
        }
    }
}
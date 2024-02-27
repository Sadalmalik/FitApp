using System.Collections.Generic;
using System.IO;
using System.Net;
using Sadalmelik.CSV;
using UnityEngine;
using Sadalmelik.FitApp.Architecture;

namespace Sadalmelik.FitApp.Main
{
    public class ApplicationCore : SingletonMonoBehaviour<ApplicationCore>
    {
        public ApplicationConfig config;

        public FoodListWidget foodListWidget;
        
        
        
        private List<FoodEntry> _food;
        
        protected override void Init()
        {
            DownloadDatabase();
        }

        private async void DownloadDatabase()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            WebClient client = new WebClient();
            
            Stream data = client.OpenRead(config.DatabaseSource);
            StreamReader reader = new StreamReader(data);
            string content = await reader.ReadToEndAsync();
            
            _food = ObjectCSVConverter.FromCSV<FoodEntry>(content);
            foodListWidget.SetList(_food);
            
            watch.Stop();
            Debug.Log($"Database ready, took {watch.ElapsedMilliseconds / 1000f}");
        }

        protected void Start()
        {
            
        } 
    }
}
using System;
using System.Collections.Generic;
using Sadalmelik.FitApp.Architecture;

namespace Sadalmelik.FitApp.Main
{
    [Serializable]
    public class ApplicationData
    {
        public UserData UserData = new UserData();
        public List<FoodDiaryEntry> FoodDiary = new List<FoodDiaryEntry>();
        public List<WeightDiaryEntry> WeightDiary = new List<WeightDiaryEntry>();
    }
}
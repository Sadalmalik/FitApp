using System;

namespace Sadalmelik.FitApp.Main
{
    [Serializable]
    public class ApplicationData
    {
        public UserData UserData;
        public FoodDiaryEntry[] FoodDiary;
        public WeightDiaryEntry[] WeightDiary;
    }
}
using System;
using Sadalmelik.FitApp.Architecture;

namespace Sadalmelik.FitApp.Main
{
    public class FoodDiaryEntry : IDataWithID
    {
        // API for DB
        public int Id => id;
        
        // Data
        public int id;
        public DateTime date;
        public int foodId;

        // Cache for fast analysis
        public float calories;
    }
}
using Sadalmelik.FitApp.Architecture;

namespace Sadalmelik.FitApp.Main
{
    public class FoodEntry : IDataWithID
    {
        // API for DB
        public int Id => id;
        
        // Data
        public int id;
        
        public string name;
        public string description;
        public string components;
        
        public float weight;
        public float calories;
        
        public float proteins;          // Белки
        public float fats;              // Жиры
        public float carbohydrates;     // Углеводы
        public float carboxylic_acid;   // Кислоты (лимонная и т.д.)
        public float ethanol;           // Спирт 100%
        public float polyol;            // Полиолы 
        public float fiber;             // Растительные волокна
    }
}
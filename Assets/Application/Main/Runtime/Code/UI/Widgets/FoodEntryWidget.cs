using TMPro;

namespace Sadalmelik.FitApp.Main
{
    public class FoodEntryWidget : ListEntryWidget<FoodEntry>
    {
        public TMP_Text LabelName;
        public TMP_Text LabelPFC;
        public TMP_Text LabelCalories;
        
        public override void SetValue(int newIndex, FoodEntry newValue)
        {
            base.SetValue(newIndex, newValue);
            
            LabelName.SetText(Value.name);
            LabelPFC.SetText($"{Value.proteins} / {Value.fats} / {Value.carbohydrates}");
            LabelCalories.SetText($"{Value.calories} kkal");
        }
    }
}
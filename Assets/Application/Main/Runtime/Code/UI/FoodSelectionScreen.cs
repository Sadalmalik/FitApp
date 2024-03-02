using System;
using System.Linq;
using Sadalmelik.FitApp.Architecture;

namespace Sadalmelik.FitApp.Main
{
    public class FoodSelectionScreen : Widget
    {
        [Inject] private SaveManager _saveManager;
        [Inject] private ApplicationCore _appCore;

        public FoodListWidget FoodList;
        
        public override void Init()
        {
            _appCore.SubscribeLoaded(HandleFoodLoaded);
        }

        private void HandleFoodLoaded()
        {
            FoodList.OnSelected += HandleFoodSelected;
            FoodList.SetList(_appCore.FoodList);
        }

        private void HandleFoodSelected(FoodEntry foodEntry)
        {
            _appCore.AddFoodToDiary(foodEntry);
        }
    }
}
using System;
using Sadalmelik.FitApp.Architecture;
using TMPro;
using UnityEngine;

namespace Sadalmelik.FitApp.Main
{
    public class DailyConsumeWidget : Widget
    {
        [Inject] private ApplicationCore _applicationCore;
        
        public TMP_Text label;

        public override void Init()
        {
            base.Init();
            
            label.SetText($"Calories: {0} / {_applicationCore.GetRecommendedCalories()}");
        }
    }
}
using System.Collections.Generic;
using Sadalmelik.FitApp.Architecture;
using UnityEngine;
using UnityEngine.UI;

namespace Sadalmelik.FitApp.Main
{
    public class ApplicationUIHierarchy : SingletonMonoBehaviour<ApplicationUIHierarchy>
    {
        public Image background;
        public Image fadeScreen;
        public RectTransform mainContainer;
        
        [Space]
        public List<Widget> Widgets;
    }
}
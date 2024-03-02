using Sadalmelik.FitApp.Architecture;
using UnityEngine;

namespace Sadalmelik.FitApp.Main
{
    public class AppStarter : MonoBehaviour
    {
        protected void Start()
        {
            var container = Container.Main;

            container.Add<SaveManager>();
            container.Add<ApplicationCore>();
            container.Add<UIManager>();
            
            container.Init();
        }
    }
}
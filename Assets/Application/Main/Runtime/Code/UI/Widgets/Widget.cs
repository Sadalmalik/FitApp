using Sadalmelik.FitApp.Architecture;
using UnityEngine;

namespace Sadalmelik.FitApp.Main
{
    public class Widget : MonoBehaviour
    {
        private void Awake()
        {
            if (!Container.Main.Active)
            {
                HandleContainerInitialized();
            }
            else
            {
                Container.Main.OnInitialized += HandleContainerInitialized;
            }
        }

        private void HandleContainerInitialized()
        {
            Container.Main.InjectAt(this);
            
            Init();
        }
        
        public virtual void Init()
        {
            
        }
    }
}
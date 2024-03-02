using Sadalmelik.FitApp.Architecture;

namespace Sadalmelik.FitApp.Main
{
    public class UIManager : SharedObject
    {
        protected ApplicationUIHierarchy Hierarchy;
        //protected UIConfig Config;
        
        public override void Init()
        {
            base.Init();

            //Config = UIConfig.Instance;
            Hierarchy = ApplicationUIHierarchy.Instance;

            foreach (var widget in Hierarchy.Widgets)
            {
                container.InjectAt(widget);
                widget.Init();
            }
        }
    }
}
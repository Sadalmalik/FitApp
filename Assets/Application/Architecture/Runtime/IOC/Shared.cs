namespace Sadalmelik.FitApp.Architecture
{
    public class SharedObject : IShared
    {
        [Inject] public Container container;

        public virtual void Init()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}
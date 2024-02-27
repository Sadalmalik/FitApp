namespace Sadalmelik.FitApp.Architecture
{
    public interface IShared : ISharedInterface
    {
        void Init();

        void Dispose();
    }
}
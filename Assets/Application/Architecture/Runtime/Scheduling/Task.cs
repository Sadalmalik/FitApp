using System;

namespace Sadalmelik.FitApp.Architecture
{
    public class Work
    {
        public event Action<Work, float> OnProgress;

        public async void Execute()
        {
            
        }
    }
}
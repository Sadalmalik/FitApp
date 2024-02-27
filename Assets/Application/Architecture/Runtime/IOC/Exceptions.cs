using System;

namespace Sadalmelik.FitApp.Architecture
{
    public class ContainerTypeException : Exception
    {
        public ContainerTypeException(string message = null) : base(message)
        {
        }
    }

    public class ContainerInitializationException : Exception
    {
        public ContainerInitializationException(string message = null) : base(message)
        {
        }
    }
}
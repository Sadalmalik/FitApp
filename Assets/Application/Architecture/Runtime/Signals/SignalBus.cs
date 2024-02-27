// Source code by Kaleb Sadalmalik
// Link: https://github.com/Sadalmalik/ShortCode/blob/master/CS/SignalBus/SignalBus.cs

using System;
using System.Collections.Generic;
using UnityEngine;

namespace GeekyHouse.Architecture
{
    public partial class SignalBus
    {
        private static SignalBus _global;

        public static SignalBus Main => _global ??= new SignalBus();

        public static bool ThrowNoHandlersException = true;

        private readonly Dictionary<Type, ISignalContainer> _signals = new Dictionary<Type, ISignalContainer>();

        public void Subscribe<T>(Action<T> handler)
        {
            var container = GetContainer<T>();

            container.Subscribe(handler);
        }

        public void Unsubscribe<T>(Action<T> handler)
        {
            var container = GetContainer<T>();

            container.Unsubscribe(handler);
            
            if (!container.IsBound())
                RemoveContainer<T>();
        }

        public void Invoke<T>(T signal)
        {
            var container = GetContainer<T>();

            container.Invoke(signal);
        }

        private bool HaveContainer<T>()
        {
            return _signals.ContainsKey(typeof(T));
        }

        private SignalContainer<T> GetContainer<T>()
        {
            var type = typeof(T);
            if (!_signals.TryGetValue(type, out var iContainer))
                _signals.Add(type, iContainer = new SignalContainer<T>());
            return iContainer as SignalContainer<T>;
        }

        private bool RemoveContainer<T>()
        {
            return _signals.Remove(typeof(T));
        }
    }
}
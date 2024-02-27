// Source code by Kaleb Sadalmalik
// Link: https://github.com/Sadalmalik/ShortCode/blob/master/CS/SignalBus/SignalBus.cs

using System;
using System.Collections.Generic;
using UnityEngine;

namespace GeekyHouse.Architecture
{
    internal class SignalContainer<T> : ISignalContainer
    {
        private readonly HashSet<Action<T>> _handlers = new HashSet<Action<T>>();

        public bool IsBound()
        {
            return _handlers.Count > 0;
        }
        
        public void Subscribe(Action<T> act)
        {
            _handlers.Add(act);
        }

        public void Unsubscribe(Action<T> act)
        {
            _handlers.Remove(act);
        }

        public void Invoke(T signal)
        {
            if (_handlers.Count == 0 && SignalBus.ThrowNoHandlersException)
            {
                throw new ArgumentException($"No handlers for signal: {signal}");
            }

            foreach (var handler in _handlers)
            {
                handler(signal);
            }
        }
    }
}
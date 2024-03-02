using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sadalmelik.FitApp.Architecture
{
    public abstract class MultitonScriptableObjects<T> : ScriptableObject where T : MultitonScriptableObjects<T>
    {
        public static List<T> Objects { get; private set; }

        public static void Init()
        {
            Objects = Resources.LoadAll<T>("").ToList();

            foreach (var instance in Objects)
            {
                instance.Initialize();
            }
        }

        protected virtual void Initialize()
        {
			
        }
    }

    public abstract class MultitonScriptableObjectsByName<T> : MultitonScriptableObjects<T> where T : MultitonScriptableObjectsByName<T>
    {
        public static Dictionary<string, T> ByName { get; private set; }

        public new static void Init()
        {
            MultitonScriptableObjects<T>.Init();
			
            ByName = new Dictionary<string, T>();
            foreach (var element in Objects)
                ByName.Add(element.name, element);
        }
    }
}
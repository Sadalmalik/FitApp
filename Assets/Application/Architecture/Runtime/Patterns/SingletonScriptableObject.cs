using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Sadalmelik.FitApp.Architecture
{
    public class SingletonScriptableObject<T> : ScriptableObject where T : SingletonScriptableObject<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (!_instance)
                {
#if UNITY_EDITOR
                    var type = typeof(T);
                    var paths = AssetDatabase.GetAllAssetPaths();
                    var path  = paths.FirstOrDefault(p => p.EndsWith(type.Name + ".asset"));
                    _instance = (T)AssetDatabase.LoadAssetAtPath(path, type);
#else
					_instance = Resources.LoadAll<T>("").First();
#endif
                    _instance.Initialize();
                }
                return _instance;
            }
        }
        
        protected virtual void Initialize()
        {
			
        }
    }
}
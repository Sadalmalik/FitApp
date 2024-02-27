using UnityEngine;

namespace Sadalmelik.FitApp.Architecture
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        public static T Instance;

        public void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this as T;
            Init();
        }

        protected abstract void Init();

        public virtual void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }
    }
}
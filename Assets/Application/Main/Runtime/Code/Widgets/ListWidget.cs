using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Sadalmelik.FitApp.Main
{
    public class ListEntryWidget<T> : MonoBehaviour
    {
        public T Value { get; private set; }

        public virtual void SetValue(T newValue)
        {
            Value = newValue;
        }
    }
    
    public class ListWidget<T> : MonoBehaviour
    {
        private ObjectPool<ListEntryWidget<T>> _pool;
        private List<ListEntryWidget<T>> _widgets;
        
        public RectTransform container;
        public ListEntryWidget<T> entryPrefab;

        public List<T> List { get; private set; }
        
        public void Awake()
        {
            _pool = new ObjectPool<ListEntryWidget<T>>(
                createFunc: Create,
                actionOnGet: HandleLock,
                actionOnRelease: HandleFree,
                actionOnDestroy: HandleDestroy);
            _widgets = new List<ListEntryWidget<T>>();
        }

        public void SetList(List<T> list)
        {
            ClearList();
            
            List = list;
            
            foreach (var entry in List)
            {
                var widget = _pool.Get();
                widget.SetValue(entry);
                _widgets.Add(widget);
                widget.transform.SetAsLastSibling();
            }
        }

        public void ClearList()
        {
            List = null;
            
            foreach (var widget in _widgets)
                if (widget)
                    _pool.Release(widget);
            _widgets.Clear();
        }

        private ListEntryWidget<T> Create()
        {
            var entry = Instantiate(entryPrefab, container);
            entry.name = entryPrefab.name;
            return entry;
        }

        private static void HandleLock(ListEntryWidget<T> entry) => entry.gameObject.SetActive(true);

        private static void HandleFree(ListEntryWidget<T> entry) => entry.gameObject.SetActive(false);
        
        private static void HandleDestroy(ListEntryWidget<T> entry) => GameObject.Destroy(entry);
    }
}
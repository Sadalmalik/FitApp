using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace Sadalmelik.FitApp.Main
{
    public class ListEntryWidget<T> : MonoBehaviour
    {
        public Button button;

        public ListWidget<T> ListWidget { get; private set; }
        public int Index { get; private set; }
        public T Value { get; private set; }

        private void Awake()
        {
            button.onClick.AddListener(HandleClick);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(HandleClick);
        }

        internal void SetListWidget(ListWidget<T> listWidget)
        {
            ListWidget = listWidget;
        }

        public virtual void SetValue(int newIndex, T newValue)
        {
            Index = newIndex;
            Value = newValue;
        }

        private void HandleClick()
        {
            ListWidget.HandleEntryClicked(Index, Value);
        }
    }

    public class ListWidget<T> : MonoBehaviour
    {
        private ObjectPool<ListEntryWidget<T>> _pool;
        private List<ListEntryWidget<T>> _widgets;

        public RectTransform container;
        public ListEntryWidget<T> entryPrefab;

        public event Action<T> OnSelected;
        public event Action<int, T> OnItemSelected;

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

            for (int i = 0; i < List.Count; i++)
            {
                var widget = _pool.Get();
                widget.SetListWidget(this);
                widget.SetValue(i, List[i]);
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

        internal void HandleEntryClicked(int index, T entry)
        {
            Debug.Log($"ListWidget<{typeof(T).Name}>.HandleEntryClicked: {index}, {entry}");
            OnItemSelected?.Invoke(index, entry);
            OnSelected?.Invoke(entry);
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
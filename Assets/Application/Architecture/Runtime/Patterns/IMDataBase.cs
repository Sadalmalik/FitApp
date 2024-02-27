using System;
using System.Collections.Generic;

namespace Sadalmelik.FitApp.Architecture
{
    public class IMDataBase<T> where T : class
    {
        private List<T> _data;
        private Dictionary<int, int> _idIndexing;

        public List<T> Data => _data;
        public bool IsIndexedByID() => _idIndexing != null;
        
        public IMDataBase(List<T>data)
        {
            _data = data;
            
            if (typeof(IDataWithID).IsAssignableFrom(typeof(T)))
            {
                _idIndexing = new Dictionary<int, int>();
                for (int i = 0; i < _data.Count; i++)
                {
                    var entry = _data[i] as IDataWithID;
                    if (entry != null)
                        _idIndexing.Add(entry.Id, i);
                }
            }
        }

        public T GetByID(int Id)
        {
            if (_idIndexing == null) return null;
            return _data[_idIndexing[Id]];
        }
    }
}
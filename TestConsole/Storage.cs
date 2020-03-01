﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TestConsole
{
    abstract class Storage<TItem> : IEnumerable<TItem>
    {
        public event Action<TItem> NewItemAdded;

        protected readonly List<TItem> _Items = new List<TItem>();

        protected Action<TItem> _AddObservers;
        protected Action<TItem> _RemoveObservers;


        public void Add(TItem Item)
        {
            if (_Items.Contains(Item))
            {
                return;
            }
            _Items.Add(Item);
            //_AddObservers?.Invoke(Item);
            var add_observers = _AddObservers;
            if (add_observers != null)
            {
                add_observers(Item);
            }

            NewItemAdded?.Invoke(Item);
        }
        public bool Remove(TItem Item)
        {
            var result = _Items.Remove(Item);
            if (result)
            {
                _RemoveObservers?.Invoke(Item);
            }
            return result;
        }

        public bool IsContains(TItem Item) => _Items.Contains(Item);

        public void Clear()
        {
            _Items.Clear();
        }
        public abstract void SaveToFile(string FileName);

        public virtual void LoadFromFile(string FileName)
        {
            Clear();
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            for (int i = 0; i < _Items.Count; i++)
            {
                //  yield - специальный модификатор
                yield return _Items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void SubscribeToAdd(Action<TItem> Observer)
        {
            _AddObservers += Observer;
        }
        public void SubscribeToRemove(Action<TItem> Observer)
        {
            _RemoveObservers += Observer;
        }

    }
}

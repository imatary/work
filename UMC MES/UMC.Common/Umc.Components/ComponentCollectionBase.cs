using System;
using System.Collections;
using System.Collections.Generic;

namespace Umc.Components
{
    public class ComponentCollectionBase<T> : IList, ICollection, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable where T : class
    {
        // Fields
        private bool _is_disposed;
        private List<T> _list;

        public ComponentCollectionBase()
        {
            this._list = new List<T>();
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (item == null)
            {
                throw Error.ArgumentNull("item");
            }
            if (!this._list.Contains(item))
            {
                this._list.Add(item);
                this.OnAddItem(item);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected virtual void OnAddItem(T item)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(T[] items)
        {
            items = items ?? new T[0];
            for (int i = 0; i < items.Length; i++)
            {
                T item = items[i];
                if (!this._list.Contains(item))
                {
                    this._list.Add(item);
                    this.OnAddItem(item);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < this._list.Count; i++)
            {
                T item = this._list[i];
                this.OnRemoveItem(item);
            }
            this._list.Clear();
        }

        protected virtual void OnRemoveItem(T item)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return ((item != null) && this._list.Contains(item));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (this._list.Count > 0)
            {
                this._list.CopyTo(array, arrayIndex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (!this._is_disposed)
            {
                if (disposing)
                {
                    this.DisposeItems();
                    this._list = null;
                    this.OnDisposed();
                }
                this._is_disposed = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void DisposeItems()
        {
            for (int i = 0; i < this._list.Count; i++)
            {
                T item = this._list[i];
                this.OnDisposeItem(item);
            }
            this._list.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnDisposed()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected virtual void OnDisposeItem(T item)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            if (item == null)
            {
                return -1;
            }
            return this._list.IndexOf(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            if (item == null)
            {
                throw Error.ArgumentNull("item");
            }
            if (!this._list.Contains(item))
            {
                this._list.Insert(index, item);
                this.OnAddItem(item);
            }
        }

        public bool Remove(T item)
        {
            if (item == null)
            {
                throw Error.ArgumentNull("component");
            }
            if (this._list.Contains(item) && this._list.Remove(item))
            {
                this.OnRemoveItem(item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            T item = this._list[index];
            this.OnRemoveItem(item);
            this._list.RemoveAt(index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public void RemoveRange(T[] items)
        {
            items = items ?? new T[0];
            for (int i = 0; i < items.Length; i++)
            {
                T item = items[i];
                if (this._list.Contains(item))
                {
                    this._list.Remove(item);
                    this.OnRemoveItem(item);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        void ICollection.CopyTo(Array array, int index)
        {
            if (this._list.Count > 0)
            {
                this._list.CopyTo((T[]) array, index);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int IList.Add(object value)
        {
            this.Add((T)value);
            return this._list.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IList.Contains(object value)
        {
            return this.Contains((T)value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int IList.IndexOf(object value)
        {
            return this.IndexOf((T)value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        void IList.Insert(int index, object value)
        {
            this.Insert(index, (T)value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        void IList.Remove(object value)
        {
            this.Remove((T)value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            return this._list.ToArray();
        }

        public int Count
        {
            get
            {
                return this._list.Count;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public T this[int index]
        {
            get
            {
                return this._list[index];
            }
            set
            {
                if (value == null)
                {
                    throw Error.ArgumentNull("value");
                }
                if (!this._list.Contains(value))
                {
                    T item = this._list[index];
                    this._list[index] = value;
                    this.OnRemoveItem(item);
                    this.OnAddItem(value);
                }
            }
        }
        public List<T> List
        {
            get
            {
                return this._list;
            }
        }



        bool ICollection.IsSynchronized
        {
            get
            {
                return false;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return ((ICollection)this._list).SyncRoot;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                return false;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = (T)value;
            }
        }


    }
}


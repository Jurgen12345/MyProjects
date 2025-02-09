using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    // [C#] If you implement the IEnumerable interface on a class, you allow its objects
    // to be part of a foreach statement. That is, you treat an object as a collection 
    // that you can iterate on its items
    public class CArrayIterable<T>: CArray<T>, IEnumerable<T>, IItemIterator<T>
    {
        //--------------------------------------------------------------------------
        public CArrayIterable() : base()
        {
        }
        //--------------------------------------------------------------------------
        public CArrayIterable(int p_nPageSize) : base(p_nPageSize)
        {
        }

        #region // IEnumerable \\
        //--------------------------------------------------------------------------
        public IEnumerator<T> GetEnumerator()
        {
            // [C# ADVANCED] The yield operator: The yield operator will pause the 
            // execution of this loop, to return a value to the code that uses
            // the object in a for each statement

            for (int i = 0; i < this.itemCount; i++)
            {
                yield return items[i];
            }
        }
        //--------------------------------------------------------------------------
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //--------------------------------------------------------------------------
        #endregion


        #region //IItemIterator\\
        private int _currentIndex = -1;
        //--------------------------------------------------------------------------
        private bool _endOf = false;
        public bool EndOf { get { return _endOf; } }
        //--------------------------------------------------------------------------
        public void Reset()
        {
            _currentIndex = -1;
            _endOf = false;
        }
         //--------------------------------------------------------------------------
        public T? Next()
        {
            _currentIndex++;
            _endOf = (_currentIndex >= this.itemCount);
            if (_endOf)
                return default(T);
            else
                return this.items[_currentIndex];
        }
        //--------------------------------------------------------------------------
        #endregion

    }
}

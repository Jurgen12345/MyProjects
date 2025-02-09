using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    // [GENERICS] This is a C# generic class declaration, in which we allow only specific types T
    //    In this example the type T must be implementing the interface IComparable. We do that to use comparison operators.
    public class CArray<T>
    {
        // ................................................................
        protected T[]? items = null;
        public T[]? Items { get { return this.items; } }
        // ................................................................
        protected int itemCount = 0;
        public int ItemCount { get { return itemCount; } }
        // ................................................................
        private int _pages = 0;
        private int _pageSize = 20;
        // ................................................................
        private int _capacity;
        public int Capacity { get { return _capacity; } }
        // ................................................................
        // You can assign an object that implements IItemComparison<T> to
        // perform custom comparison using a specific property of T

        protected IItemComparison<T>? _comparisonBy = null;
        public IItemComparison<T>? ComparisonBy { get { return _comparisonBy; } set { _comparisonBy = value;} }
        // ................................................................
        // [C#] This special property is called an indexer. It allows your object to be used as an array;
        public T? this[int index] { get { return this.items[index]; } set { this.items[index] = value; }  }
        // ................................................................


        //--------------------------------------------------------------------------
        public CArray()
        {
            this.expand(); // [BEST PRACTICES] We don't copy-paste the creation of the array object, instead using expand()
        }
        //--------------------------------------------------------------------------
        public CArray(int p_nPageSize)
        {
            this._pageSize = p_nPageSize;
            this.expand(); // [BEST PRACTICES] We don't copy-paste the creation of the array object, instead using expand()
        }
        //--------------------------------------------------------------------------
        private void expand()
        {
            // Increase the pages (thus the capacity) and create a new array object.
            // When called from the constructor the value of this._pages will be 0.
            this._pages++;
            this._capacity = _pages * _pageSize;
            T[] newArray = new T[this._capacity];

            // Copy all the items of an existing array object to the new array object. Costs O(n)
            if (this.items != null)
                this.items.CopyTo(newArray, 0);

            // The reference is replace to point to the new array object, the old array object is flagged as garbage.
            this.items = newArray;
        }
        //--------------------------------------------------------------------------
        public void Clear()
        {
            // Reset the item count to zero, the page count to 0, nullify the array object reference and expand
            this.itemCount = 0;
            this._pages = 0;
            this.items = null;
            expand();

            Debug.WriteLine("Emptied the array. The new capacity can hold " + _capacity + " items");
        }
        //--------------------------------------------------------------------------
        protected int compareItems(T p_oThisItem, T p_oOtherItem)
        {
            int nResult = 1;

            // Check if a helper object for specific comparison (that implements IItemComparison)
            // has been supplied to this array data structure and use it by priority
            if (this.ComparisonBy != null)
                nResult = this.ComparisonBy.Compare(p_oThisItem, p_oOtherItem);
            else
            { 
                // Default comparison of two items if they implement the IComparable interface
                IComparable<T>? iCurrentItem = p_oThisItem as IComparable<T>;
                if (iCurrentItem != null)
                    nResult = iCurrentItem.CompareTo(p_oOtherItem);
            }

            return nResult;
        }
        //--------------------------------------------------------------------------
        internal void appendItem(T p_oItem)
        {
            if (itemCount >= _capacity)
            { 
                expand();
                Debug.WriteLine("Expanding array capacity to hold " + _capacity + " items");
            }


            items[itemCount] = p_oItem;
            itemCount++;
        }
        //--------------------------------------------------------------------------
        private void moveItemsForInsert(int p_nInsertPosition)
        {
            for (int i = this.itemCount - 1; i >= p_nInsertPosition; i--)
                this.items[i + 1] = this.items[i];

            items[p_nInsertPosition] = default(T);
        }
        //--------------------------------------------------------------------------
        protected void insertItem(int p_nIndex, T p_oItem)
        {
            if (itemCount >= _capacity)
            { 
                expand();
                Debug.WriteLine("Expanding array capacity to hold " + _capacity + " items");
            }

            // Move items to insert at p_nIndex with O(n) cost
            this.moveItemsForInsert(p_nIndex);
            items[p_nIndex] = p_oItem;
            this.itemCount++;
        }
        //--------------------------------------------------------------------------
        protected void deleteLastItem()
        {
            items[itemCount - 1] = default(T);
            itemCount--;
        }
        //--------------------------------------------------------------------------            
        protected void deleteItem(int p_nIndex)
        {
            // For any item runs a for loop with O(n) cost
            for (int i = p_nIndex; i < (this.itemCount - 1); i++)
                this.items[i] = this.items[i + 1];
            items[itemCount - 1] = default(T);
            itemCount--;
        }
        //--------------------------------------------------------------------------            
        protected void remove(T p_oItem)
        {
            // For any item runs a for loop with O(n) cost
            for (int i = 0; i < this.itemCount; i++)
            {
                // [C#] The == operator does not work with object references of generic type T.
                // Instead we must use the Object.ReferenceEquals static (class) method
                if (Object.ReferenceEquals(this.items[i], p_oItem))
                { 
                    deleteItem(i);
                    break;
                }
            }
        }
        //--------------------------------------------------------------------------            
        public void DeleteFirstItem()
        {
            this.deleteItem(0);
        }
        //--------------------------------------------------------------------------            
        public void DeleteLastItem()
        {
            this.deleteLastItem();
        }
        //--------------------------------------------------------------------------
        public void Delete(int p_nIndex)
        {
            if (p_nIndex == (this.itemCount - 1))
                // For the last item runs a simple logic with O(1) cost
                this.deleteLastItem();
            else if ((p_nIndex >= 0) && (p_nIndex < this.itemCount))
                this.deleteItem(p_nIndex);
        }
        //--------------------------------------------------------------------------
        // This method will help us display the data structure in the UI
        public override String ToString()
        {
            String sResult = "";
            for (int i = 0; i < this._capacity; i++)
            {
                if (i > 0)
                {
                    sResult += "\r\n";
                }
                sResult += $"{i:d2} : {this.items[i]} "; // <- Notice the format d2 to pad the integer with zeros so that it has 2 digits
            }
            return sResult;
        }
        //--------------------------------------------------------------------------
        public string ToDelimitedList(char p_cDelimiter = ',')
        {
            String sResult = "";
            for (int i = 0; i < this.itemCount; i++)
            {
                sResult += this.items[i];
                if (i < this.itemCount - 1)
                    sResult += p_cDelimiter;
            }
            return sResult;
        }
        //--------------------------------------------------------------------------
        public String ToCommaList()
        {
            return "[" + ToDelimitedList(',') + "]";
        }
        //--------------------------------------------------------------------------

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    public class CStack<T>: CArrayIterable<T>
    {
        public bool IsEmpty { get {return this.itemCount == 0;} }

        //--------------------------------------------------------------------------
        public CStack() : base()
        {
        }
        //--------------------------------------------------------------------------
        public CStack(int p_nPageSize) : base(p_nPageSize)
        {
        }
        //--------------------------------------------------------------------------
        public void Push(T item)
        {
            this.appendItem(item);
        }
        //--------------------------------------------------------------------------
        public T? Pop()
        {
            T? oItem = this.Peek();
            if (oItem != null) // If there is even one item in the data structure
                this.deleteLastItem();
            return oItem;
        }
        //--------------------------------------------------------------------------
        // [C#] This method returns an object or null, because of a nullable return type T?
        // Peek will return null if no more items exist in the data structure
        public T? Peek()
        {
            // [C#] This is the equivalent of null 
            T? oItemOnTop = default(T);

            int nStackTopIndex = this.itemCount - 1;
            if (nStackTopIndex >= 0)
                oItemOnTop = this.items[nStackTopIndex];
            return oItemOnTop;
        }
        //--------------------------------------------------------------------------
    }
}

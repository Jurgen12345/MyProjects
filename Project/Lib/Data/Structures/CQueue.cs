using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    public class CQueue<T>: CArrayIterable<T>
    {
        public bool IsEmpty { get { return this.itemCount == 0; } }

        //--------------------------------------------------------------------------
        public CQueue() : base()
        {
        }
        //--------------------------------------------------------------------------
        public CQueue(int p_nPageSize) : base(p_nPageSize)
        {
        }
        //--------------------------------------------------------------------------
        public void Enqueue(T item)
        {
            this.appendItem(item);
        }
        //--------------------------------------------------------------------------
        public T? Dequeue()
        {
            T? oItem = this.Peek();
            if (oItem != null) // If there is even one item in the data structure
                this.deleteItem(0);
            return oItem;
        }
        //--------------------------------------------------------------------------
        // [C#] This method returns an object or null, because of a nullable return type T?
        // Peek will return null if no more items exist in the data structure
        public T? Peek()
        {
            T? oFirstItem = default(T);
            if (this.itemCount > 0)
                oFirstItem = this.items[0];
            return oFirstItem;
        }
        //--------------------------------------------------------------------------
    }
}

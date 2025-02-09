using Lib.Data.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    public class CTreeNodeQueue<T>: CLinkedList<CTreeNode<T>>
    {
        public bool IsEmpty { get { return this.ItemCount == 0; } }

        //--------------------------------------------------------------------------
        public CTreeNodeQueue() : base()
        {
        }
        //--------------------------------------------------------------------------
        public void Enqueue(CTreeNode<T> item)
        {
            this.appendItem(item);
        }
        //--------------------------------------------------------------------------
        public CTreeNode<T>? Dequeue()
        {
            CTreeNode<T>? oItem = this.Peek();
            if (oItem != null)
                this.deleteItem(0);
            return oItem;
        }
        //--------------------------------------------------------------------------
        // Peek will return null if there is no first node in the linked list
        public CTreeNode<T>? Peek()
        {
            CTreeNode<T>? oFirstItem = null;
            if (this.First != null)
                oFirstItem = this.First.Value;
            return oFirstItem;
        }
        //--------------------------------------------------------------------------
    }
}

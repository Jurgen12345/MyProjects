using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    public class CSinglyLinkedList<T>
    {
        // ................................................................
        protected CLinkedListNode<T>? first = null;
        public CLinkedListNode<T>? First { get { return first; } }
        // ................................................................
        protected CLinkedListNode<T>? last = null;
        public CLinkedListNode<T>? Last { get { return last; } }
        // ................................................................
        protected int itemCount = 0;
        public int ItemCount { get { return itemCount; } }
        // ................................................................
        // [C#] This special property is called an indexer. It allows your object to be used as an array;
        public T? this[int index]
        {
            get
            {
                CLinkedListNode<T>? oFoundNode = this.locateNode(index);
                if (oFoundNode != null)
                    return oFoundNode.Value;
                else
                    return default(T);
            }

            set
            {
                CLinkedListNode<T>? oFoundNode = this.locateNode(index);
                if (oFoundNode != null)
                    oFoundNode.Value = value;
            }
        }
        // ................................................................
        // You can assign an object that implements IItemComparison<T> to
        // perform custom comparison using a specific property of T

        protected IItemComparison<T>? _comparisonBy = null;
        public IItemComparison<T>? ComparisonBy { get { return _comparisonBy; } set { _comparisonBy = value; } }
        // ................................................................



        //--------------------------------------------------------------------------
        public CSinglyLinkedList()
        {
            Clear();
        }
        //--------------------------------------------------------------------------
        public void Clear()
        {
            // Remove the two references that hold the linked-list chain in the memory
            // After this the garbage collector will dispose the chain of unused objects
            this.first = null;
            this.last = null;
            this.itemCount = 0;
        }
        //--------------------------------------------------------------------------
        // [OO PRINCIPLES] [POLYMORPHISM] Virtual Methods
        //  This method is declared as virtual so that
        // the CDoubleLinkedList or any other descendand can override it and create
        // a node object that belongs to a descendand class of CLinkedListNode.

        // This is like a plug for your code, that you can plug-in a different class by overriding.
        protected virtual CLinkedListNode<T> createNode(T p_oItemValue)
        {
            // Create the node object
            CLinkedListNode<T> oNode = new CLinkedListNode<T>();
            
            // Box the value inside the new node
            oNode.Value = p_oItemValue;

            return oNode;
        }
        //--------------------------------------------------------------------------
        protected void appendItem(T p_oItemValue)
        {
            // Create a new node in the chain and box the value inside it.
            CLinkedListNode<T> oNewLastNode = this.createNode(p_oItemValue); // virtual call

            if (itemCount == 0)
                // Is it the first node appended to the linked-list?
                this.first = oNewLastNode;
            else
            { 
                // Set the link of the last node to point to to the new node (append).
                if (this.last != null)
                    this.last.Next = oNewLastNode;
            }

            // In any case this node becomes the last, and the count increases.
            this.last = oNewLastNode;
            itemCount++;
        }
        //--------------------------------------------------------------------------    
        protected void prependItem(T p_oItemValue)
        {
            // Create a new node in the chain and box the value inside it.
            CLinkedListNode<T> oNewFirstNode = this.createNode(p_oItemValue); // virtual call

            if (itemCount == 0)
                // Is it the first node prepended to the linked-list?
                // If yes, the first is also the last.
                this.last = oNewFirstNode;
            else
                // Set the link of the new node to point to the old first node.
                oNewFirstNode.Next = this.first;

            // In any case this nodes the first, and the count increases.
            this.first = oNewFirstNode;
            itemCount++;
        }
        //--------------------------------------------------------------------------
        protected void insertItem(int p_nIndex, T p_oItemValue)
        {
            CLinkedListNode<T>? oPreviousNode = null;
            if (p_nIndex == 0)
                this.prependItem(p_oItemValue);
            else if (p_nIndex >= this.itemCount)
                this.appendItem(p_oItemValue);
            else
            {
                // Create a new node in the chain and box the value inside it.
                CLinkedListNode<T> oInsertedNode = this.createNode(p_oItemValue); // virtual call

                // For inserting B between A -> C, we need to find the insertion node
                // that will become the previous node to B.
                oPreviousNode = locateNode(p_nIndex - 1);

                // Inserting B between A -> C is done with the following steps
                if (oPreviousNode != null)
                {
                    oInsertedNode.Next = oPreviousNode.Next;      // B -> C
                    oPreviousNode.Next = oInsertedNode;           // A -> B ( -> C )
                }

                itemCount++;
            }
        }
        //--------------------------------------------------------------------------
        protected void deleteFirstItem()
        {
            if (this.first != null)
            {
                // Keep the node after the first node (the one that will become the first) 
                CLinkedListNode<T>? oNewFirstNode = this.first.Next;

                // Remove the link from the first node that will be deleted.
                this.first.Next = null;

                // Set the reference to the kept node as the first node and decrease count.
                this.first = oNewFirstNode;
                itemCount--;

                // In case we deleted the last node set the reference to null
                if (itemCount == 0)
                    this.last = null;
            }
        }
        //--------------------------------------------------------------------------
        // [OO PRINCIPLES] [POLYMORPHISM] Virtual Methods
        // This will be overriden in the CDoubleLinkedList with a different deletion logic
        protected virtual void deleteLastItem()
        {
            this.locatePreviousNodeAndDelete(this.itemCount - 1);
        }
        //--------------------------------------------------------------------------
        // This linked-list traversal visits nodes in a sequential manner. This has an O(n) cost.
        private void locatePreviousNodeAndDelete(int p_nIndex)
        {
            // Initialize the two nodes that we need to find, so we can perform a deletion
            CLinkedListNode<T>? oNodeToDelete = this.first;
            CLinkedListNode<T>? oPreviousOfNodeToDelete = this.first;

            // Traverse the linked-list to find the position, the node to be deleted and its previous. 
            int nIndex = 0;
            while (nIndex < p_nIndex)
            {   
                oPreviousOfNodeToDelete = oNodeToDelete; // Keep the previous node of the one that will be deleted
                oNodeToDelete = oNodeToDelete?.Next;
                nIndex++;
            }

            // Deleting B in the chain A -> B -> C is done by skipping the node
            // that is deleted, pointing to its next node
            if ((oNodeToDelete != null) && (oPreviousOfNodeToDelete != null))
            {
                CLinkedListNode<T>? oNextNode = oNodeToDelete.Next; // C
                oPreviousOfNodeToDelete.Next = oNextNode;           // A -> C 
                oNodeToDelete.Next = null;                          // Remove the link from the item that is beeing deleted.
            }

            // In case the last item was deleted, its previous is now the last one
            if (oNodeToDelete == this.Last)
                this.last = oPreviousOfNodeToDelete;

            itemCount--;
        }
        //--------------------------------------------------------------------------
        protected void remove(T p_oNodeValue)
        {
            // [C#] The == operator does not work with object references of generic type T.
            // Instead we must use the Object.ReferenceEquals static (class) method
            if (Object.ReferenceEquals(this.First.Value, p_oNodeValue))
                this.deleteFirstItem();
            else if (Object.ReferenceEquals(this.Last.Value, p_oNodeValue))
                this.deleteLastItem();
            else
            {
                CLinkedListNode<T>? oPreviousOfNodeToDelete = null;
                CLinkedListNode<T>? oNodeToDelete = this.First;
                while (oNodeToDelete != null)
                {
                    if (Object.ReferenceEquals(oNodeToDelete.Value, p_oNodeValue))
                    {
                        // Deleting B in the chain A -> B -> C is done by skipping the node
                        // that is deleted, pointing to its next node
                        if ((oNodeToDelete != null) && (oPreviousOfNodeToDelete != null))
                        {
                            CLinkedListNode<T>? oNextNode = oNodeToDelete.Next; // C
                            oPreviousOfNodeToDelete.Next = oNextNode;           // A -> C 
                            oNodeToDelete.Next = null;                          // Remove the link from the item that is beeing deleted.
                        }

                        // In case the last item was deleted, its previous is now the last one
                        if (oNodeToDelete == this.Last)
                            this.last = oPreviousOfNodeToDelete;

                        itemCount--;
                    }
                    oNodeToDelete = oNodeToDelete.Next;
                }
            }
        }
        //--------------------------------------------------------------------------
        protected void deleteItem(int p_nIndex)
        {
            if (p_nIndex == 0)
                this.deleteFirstItem();     // For the first item runs a simple logic with O(1) cost.
            else if (p_nIndex >= (this.itemCount - 1))  
                this.deleteLastItem();      // O(n) cost for singly linked list, O(1) cost for doubly linked list.
            else if ((p_nIndex > 0) && (p_nIndex < (this.itemCount - 1)))
                this.locatePreviousNodeAndDelete(p_nIndex);
        }
        //--------------------------------------------------------------------------
        // This linked-list traversal visits nodes in a sequential manner. This has an O(n) cost.
        private CLinkedListNode<T>? locateNode(int p_nIndex)
        {
            int nIndex = 0;
            CLinkedListNode<T>? oCurrentNode = this.First;
            while (nIndex < p_nIndex)
            {
                oCurrentNode = oCurrentNode?.Next;
                nIndex++;
            }
            return oCurrentNode;
        }
        //--------------------------------------------------------------------------
        // This method will help us display the data structure in the UI
        public override string ToString()
        {
            int nIndex = 0;
            String sResult = "";
            CLinkedListNode<T>? oCurrentNode = this.first;
            while (oCurrentNode != null)
            {
                if (nIndex > 0)
                    sResult += "\r\n";

                sResult += $"{nIndex:d2} : {oCurrentNode.ToString()}";

                oCurrentNode = oCurrentNode?.Next;
                nIndex++;
            }
            return sResult;
        }
        //--------------------------------------------------------------------------
        public String ToCommaList()
        {
            String sResult = "[";
            CLinkedListNode<T>? oCurrentNode = this.first;
            while (oCurrentNode != null)
            {
                if (oCurrentNode.Value != null)
                    sResult += oCurrentNode.Value.ToString();
                else
                    sResult += "null";
                if (oCurrentNode.Next != null)
                    sResult += ",";
                oCurrentNode = oCurrentNode?.Next;
            }
            sResult += "]";
            return sResult;
        }
        //--------------------------------------------------------------------------    



    }
}

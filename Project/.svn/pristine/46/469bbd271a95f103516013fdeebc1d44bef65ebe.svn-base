using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    public class CDoublyLinkedList<T>: CSinglyLinkedList<T>
    {

        // ................................................................
        // [C#] The new modifier allows us to redeclare an inherited member, e.g. here these two properties
        // The code will use these declarations instead the inherited ones.
        new public CDoublyLinkedListNode<T>? First { get { return (CDoublyLinkedListNode<T>?)first; } }
        // ................................................................
        new public CDoublyLinkedListNode<T>? Last { get { return (CDoublyLinkedListNode<T>?)last; } }
        // ................................................................


        //--------------------------------------------------------------------------
        public CDoublyLinkedList(): base()  // [INHERITANCE] Base runs the code of the CSinglyLinkedList constructor
        {
        }
        //--------------------------------------------------------------------------
        // [OO PRINCIPLES] [POLYMORPHISM] Virtual Methods
        // This method override the one on CSinglyLinkedList
        // It will create a CDoublyLinkedListNode object that can be used
        // as its more general class type CLinkedListNode (it is compatible through inheritance).

        // We plug in a different node class to our linked list, without rewriting the code
        protected override CLinkedListNode<T> createNode(T p_oItemValue)
        {
            return new CDoublyLinkedListNode<T>() { Value = p_oItemValue };
        }
        //--------------------------------------------------------------------------
        // [OO PRINCIPLES] [POLYMORPHISM] Virtual Methods
        // We override the method of the singly linked list, so that we can implement
        // the deletion of the last node in one step, i.e. O(1) cost.
        protected override void deleteLastItem()
        {
            if (this.Last != null)
            {
                // For the double link list we use CDoubleLinkedListNode local variables, so we can safely typecat.
                CDoublyLinkedListNode<T>? oLastNode = this.last as CDoublyLinkedListNode<T>;
                
                // The previous to the last node will become the last node
                CDoublyLinkedListNode<T>? oNewLastNode = oLastNode?.Previous;

                // Remove the bi-directional link to the last node, the one that is deleted.
                if (oNewLastNode != null)
                    oNewLastNode.Next = null;

                // This becomes the new last node and we decreate the item count.
                this.last = oNewLastNode;
                itemCount--;

                // In case we deleted the only node we set the first node reference to null
                if (itemCount == 0)
                    this.first = null;
            }
        }
        //--------------------------------------------------------------------------
        // The doubly linked list supports node swaping in O(1) cost, that can be used for Bubble Sort.
        public void SwapWithNext(CDoublyLinkedListNode<T>? p_oNode)
        {
            if (p_oNode != null)
            {
                // In a chain  A -> B -> C -> D, we swap B (p_oItem) with C
                CDoublyLinkedListNode<T>? A = p_oNode.Previous;         
                CDoublyLinkedListNode<T>? B = p_oNode;                  
                CDoublyLinkedListNode<T>? C = p_oNode.Next;             
                CDoublyLinkedListNode<T>? D = null;
                if (C != null)
                    D = C.Next;       

                bool bIsFirstNode = (B == this.First);
                bool bIsLastNode  = (B == this.Last);

                // Build the new chain  A <-> C <-> B <-> D
                if (C != null)
                {
                    C.Previous = A;    // Step 1: A <-> C
                    C.Next = B;        // Step 2: C <-> B    (Chain: A <-> C <-> B ) 
                }
                if (B != null)
                    B.Next = D;        // Step 3: B <-> D    (Chain: A <-> C <-> B <-> D )       


                if (bIsFirstNode)
                    this.first = C;
                if (bIsLastNode)
                    this.first = B;
            }
        }
        //--------------------------------------------------------------------------
        public void SwapWithPrevious(CDoublyLinkedListNode<T>? p_oItem)
        {   
            SwapWithNext(p_oItem.Previous);
        }
        //--------------------------------------------------------------------------    
    }

}

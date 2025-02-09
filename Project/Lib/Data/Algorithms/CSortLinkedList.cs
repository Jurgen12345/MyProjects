using Lib.Data.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Algorithms
{
    public class CSortLinkedList<T> : CAlgorithmForLinkedList<T>
    {
        //--------------------------------------------------------------------------
        public void BubbleSort(CSinglyLinkedList<T> p_oLinkedList)
        {
            this.list = p_oLinkedList;
            this.BubbleSort();
        }
        //--------------------------------------------------------------------------
        public void BubbleSort()
        {
            CDoublyLinkedList<T>? oList = null;
            if (this.list != null) 
                oList = this.list as CDoublyLinkedList<T>;
            
            // [C#] Example of throwing an exception. We do this in some state of our program
            // to indicate wrong use of methods or invalid states of the program,
            // here, if someone gives a singly linked list, or has provided null instead of an object
            if (oList == null)
                throw new Exception("This implementation of bubble sort can be perform on a doubly linked list only");

            IsFinished = false;
            // Iterate on items, starting from the second to the last item. These are the passes of the algorithm.
            for (int nPassNumber = 1; nPassNumber < this.list.ItemCount; nPassNumber++)
            {
                // The upward inner for loop runs from the start up to the count of items minus the current index.
                CDoublyLinkedListNode<T>? oCurrentNode = oList.First;
                int j = 0;
                while((j < this.list.ItemCount - nPassNumber) && (oCurrentNode != null))
                {
                    Debug.WriteLine($"[>] Pass {nPassNumber} j={j} ({this.list.ItemCount - nPassNumber -1}) current node: {oCurrentNode}");
                    CDoublyLinkedListNode<T>? oNextNode = oCurrentNode.Next;
                    if (compare(oList.ComparisonBy, oCurrentNode, oNextNode.Value) > 0)
                    {
                        oList.SwapWithNext(oCurrentNode);
                        Debug.WriteLine($"SWAPPED: {oList.ToCommaList()}");
                    }
                    else
                        // Moving to next if the current node was not swapped.
                        // Terminates the loop if it goes to the last without a swap.
                        oCurrentNode = oCurrentNode?.Next;
                    algorithmStep(oList, nPassNumber, j, oCurrentNode.ToString()); //For step-by-step visualization
                    
                    j ++;;
                }
            }
            IsFinished = true;
        }
        //--------------------------------------------------------------------------

    }
}

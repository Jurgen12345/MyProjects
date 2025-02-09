using Lib.Data.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Algorithms
{
    public class CSearchLinkedList<T>: CAlgorithmForLinkedList<T>
    {
        //--------------------------------------------------------------------------
        public CLinkedListNode<T>? ExhaustiveSearch(CSinglyLinkedList<T> p_oLinkedList, T p_oSearchValue)
        {
            this.list = p_oLinkedList;
            return this.ExhaustiveSearch(p_oSearchValue);
        }
        //--------------------------------------------------------------------------
        public CLinkedListNode<T>? ExhaustiveSearch( T p_oSearchValue)
        {
            CLinkedListNode<T>? oFoundNode = null;
            this.IsFinished = false;

            CLinkedListNode<T>? oCurrentItem = this.list.First;
            while (oCurrentItem != null)
            {
                if (this.compare(this.list.ComparisonBy, oCurrentItem, p_oSearchValue) == 0)
                {
                    oFoundNode = null;
                    break;
                }

                oCurrentItem = oCurrentItem.Next;
            }
            
            this.IsFinished = true;
            return oCurrentItem;
        }
        //--------------------------------------------------------------------------
    }
}

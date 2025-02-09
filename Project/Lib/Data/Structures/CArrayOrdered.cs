using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lib.Data.Structures
{
    public class CArrayOrdered<T> : CArrayIterable<T> where T : IComparable<T>
    { 
        //--------------------------------------------------------------------------
        public CArrayOrdered() : base()
        {
        }
        //--------------------------------------------------------------------------
        public CArrayOrdered(int p_nPageSize) : base(p_nPageSize)
        {
        }
        //--------------------------------------------------------------------------
        public void Add(T p_oItem)
        {
            // First part of this method is to determine the insertion position.
            int nInsertionPos = 0;
            while (nInsertionPos <= this.itemCount - 1)
            {
                // Compare item at current position if it is greater in order that the given p_sItem
                IComparable<T>? iCurrentItem = (IComparable<T>)this.items[nInsertionPos];
                if (iCurrentItem?.CompareTo(p_oItem) > 0)
                    // If there is an item that is higher in alphabetic order we stop the loop to insert here
                    break;

                nInsertionPos++;
            }

            // Instead of writing the same insertion logic again, we re-use it through inheritance
            this.insertItem(nInsertionPos, p_oItem);
        }
        //--------------------------------------------------------------------------
        public void Append(T p_oItem) // Just a precaution, if Append is called on this object
        {
            this.Add(p_oItem);
        }
        //--------------------------------------------------------------------------
        // Binary search algorithm
        public int FastSearch(T p_oSearchValue)
        {
            Debug.WriteLine($"[>] Searching for {p_oSearchValue}");
            int nFoundIndex = -1;
            int nCountSteps = 0;

            int nStartIndex = 0;
            int nEndIndex = this.itemCount;

            // Continue to loop until the is nothing to dichotomize
            while ((nEndIndex - nStartIndex >= 0) && (nStartIndex < this.itemCount))
            {
                nCountSteps++;
                int nMiddleIndex = nStartIndex + (nEndIndex - nStartIndex) / 2;
                Debug.WriteLine($"|_ Searching in interval [{nStartIndex},{nEndIndex}] middle is {nMiddleIndex}");

                IComparable<T> iItem = (IComparable<T>)this.items[nMiddleIndex];
                if (iItem.CompareTo(p_oSearchValue) > 0) // greater than 
                {
                    Debug.WriteLine("    Search interval end moved just before middle index.");
                    nEndIndex = nMiddleIndex - 1;  // In the next step it will check the middle of the left split
                }
                else if (iItem.CompareTo(p_oSearchValue) < 0) // less than
                {
                    Debug.WriteLine("    Search interval start moved just after middle index.");
                    nStartIndex = nMiddleIndex + 1; // In the next step it will check the middle of the right split   
                }
                else if (iItem.CompareTo(p_oSearchValue) == 0) //equals
                {
                    nFoundIndex = nMiddleIndex;
                    break;
                }
            }
            Debug.WriteLine($"Search completed in {nCountSteps} steps");
            
            return nFoundIndex;
        }
        //--------------------------------------------------------------------------
    }
}

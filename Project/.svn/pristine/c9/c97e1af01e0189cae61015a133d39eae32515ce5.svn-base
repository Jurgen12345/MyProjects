using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Lib.Data.Structures;

namespace Lib.Data.Algorithms
{
    public class CSort<T>: CAlgorithmForArray<T>
    {
        //--------------------------------------------------------------------------
        public CSort() : base()
        {

        }
        //--------------------------------------------------------------------------
        public CSort(CArray<T> p_oArray) : base(p_oArray)
        {
        }
        //--------------------------------------------------------------------------
        public void BubbleSortInt(CArray<int> p_oArray)
        {
            IsFinished = false;
            // Iterate on items, starting from the second to the last item. These are the passes of the algorithm.
            for (int nPassNumber = 1; nPassNumber < p_oArray.ItemCount; nPassNumber++)
            {
                // The upward inner for loop runs from the start up to the count of items minus the current index.
                Boolean bHasSwapped = false;
                for (int j = 0; j < (p_oArray.ItemCount - nPassNumber); j++)
                {
                    int nCurrentItem = p_oArray.Items[j];
                    int nNextItem = p_oArray.Items[j + 1];

                    if (nCurrentItem > nNextItem)
                    {    // Swapping current item with its next
                        Debug.WriteLine($"Pass #{nPassNumber} (j={j}): Swapping {nCurrentItem.ToString()} with {nNextItem.ToString()}");
                        p_oArray.Items[j] = nNextItem;
                        p_oArray.Items[j + 1] = nCurrentItem;
                        bHasSwapped = true;
                        Debug.WriteLine($"  items become: {p_oArray.ToCommaList()}");
                    }
                }
                if (!bHasSwapped)
                    break;
            }
            IsFinished = true;
        }
        //--------------------------------------------------------------------------
        public void BubbleSort(CArray<T> p_oArray)
        {
            this.array = p_oArray;
        }
        //--------------------------------------------------------------------------
        public void BubbleSort()
        {
            IsFinished = false;
            // Iterate on items, starting from the second to the last item. These are the passes of the algorithm.
            for (int nPassNumber = 1; nPassNumber < this.array.ItemCount; nPassNumber++)
            {
                // The upward inner for loop runs from the start up to the count of items minus the current index.
                Boolean bHasSwapped = false;
                for (int j = 0; j < (this.array.ItemCount - nPassNumber); j++)
                {
                    T oCurrentItem = this.array.Items[j];
                    T oNextItem = this.array.Items[j + 1];

                    // Compare if oCurrentItem is greater than oNextItem
                    if (compare(this.array.ComparisonBy, oCurrentItem, oNextItem) > 0)
                    {    // Swapping current item with its next
                        Debug.WriteLine($"Pass #{nPassNumber} (j={j}): Swapping {oCurrentItem.ToString()} with {oNextItem.ToString()}");
                        this.array.Items[j] = oNextItem;
                        this.array.Items[j + 1] = oCurrentItem;
                        bHasSwapped = true;
                        Debug.WriteLine($"  items become: {this.array.ToCommaList()}");
                    }
                    algorithmStep(this.array, nPassNumber, j, oCurrentItem.ToString()); //For step-by-step visualization
                }
                if (!bHasSwapped)
                    break;
            }
            IsFinished = true;
        }
        //--------------------------------------------------------------------------
        public void InsertionSort(CArray<T> p_oArray)
        {
            this.array = p_oArray;
            InsertionSort();
        }
        //--------------------------------------------------------------------------
        public void InsertionSort()
        {
            IsFinished = false;
            Debug.WriteLine($"Insertion sort on array of strings, initial items: {this.array.ToCommaList()}");
            // Iterate on items, starting from the second to the last item. These are the passes of the algorithm.
            int nCurrentIndex = 1;
            while (nCurrentIndex < this.array.ItemCount)
            {
                T oCurrentItem = this.array.Items[nCurrentIndex];
                // This downward loop finds the insert index while moving the items. 
                // It starts just before the current index of the outer loop
                int j = nCurrentIndex - 1;
                while (j >= 0)
                {
                    algorithmStep(this.array, nCurrentIndex, j, oCurrentItem.ToString()); //For step-by-step visualization

                    T oPrevItem = this.array.Items[j];

                    // If one of the previous items is lower in order than the current one
                    // then this will be the insert position
                    if ( compare(this.array.ComparisonBy, oPrevItem, oCurrentItem) < 0)
                        break;

                    // Moving items to make space for insertion
                    this.array.Items[j + 1] = oPrevItem;
                    j--;
                    Debug.WriteLine($"Pass #{nCurrentIndex}: Moving for insert at j+1={j + 1} items become: {this.array.ToCommaList()}");
                }

                // The insert position is 0 if the loop finishes normally or other value due to a break
                this.array.Items[j + 1] = oCurrentItem;
                nCurrentIndex++;
                Debug.WriteLine($"Pass #{nCurrentIndex - 1}: Inserting at at j+1={j + 1} items become: {this.array.ToCommaList()}");

                algorithmStep(this.array, nCurrentIndex, j, oCurrentItem.ToString()); //For step-by-step visualization
            }


            IsFinished = true;
        }
        //--------------------------------------------------------------------------    
    }
}

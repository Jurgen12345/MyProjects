using Lib.Data.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Algorithms
{
    public class CQuickSort<T> : CAlgorithmForArray<T>
    {
        //--------------------------------------------------------------------------
        public CQuickSort() : base()
        {

        }
        //--------------------------------------------------------------------------
        public CQuickSort(CArray<T> p_oArray) : base(p_oArray)
        {
        }
        //--------------------------------------------------------------------------    
        protected void swapItems(T[] p_oSet, int p_nFirstIndex, int p_nSecondIndex)
        {
            T oKeep = p_oSet[p_nFirstIndex];
            p_oSet[p_nFirstIndex] = p_oSet[p_nSecondIndex];
            p_oSet[p_nSecondIndex] = oKeep;
        }
        //--------------------------------------------------------------------------    
        protected int divide(T[] p_oSet, int p_nLeftIndex, int p_nRightIndex)
        {
            T oPivot = p_oSet[p_nRightIndex]; // Choose the rightmost element as pivot

            int nDivisionIndex = p_nLeftIndex - 1;
            for (int j = p_nLeftIndex; j < p_nRightIndex; j++)
            {
                if (this.compare(p_oSet[j], oPivot) < 0) // array[j] <= pivot
                {
                    nDivisionIndex++;
                    swapItems(p_oSet, nDivisionIndex, j);
                }
            }

            // Bring the pivot item to the current index that will be used to divide the set
            swapItems(p_oSet, nDivisionIndex + 1, p_nRightIndex);
            return nDivisionIndex + 1;
        }
        //--------------------------------------------------------------------------    
        public void recuseQuickSort(T[] p_oSet, int p_nLeftIndex, int p_nRightIndex, int p_nDepth)
        {
            if (p_nLeftIndex < p_nRightIndex)
            {
                this.stepCount ++;
                int nDivisionIndex = divide(p_oSet, p_nLeftIndex, p_nRightIndex);
                
                debugArrayPartitions("Partitions", p_oSet, p_nLeftIndex, nDivisionIndex, p_nRightIndex, p_nDepth);

                recuseQuickSort(p_oSet, p_nLeftIndex, nDivisionIndex - 1, p_nDepth + 1);
                recuseQuickSort(p_oSet, nDivisionIndex + 1, p_nRightIndex, p_nDepth + 1);

                debugArrayPartitions("Sorted", p_oSet, p_nLeftIndex, nDivisionIndex, p_nRightIndex, p_nDepth);
            }
        }
        //--------------------------------------------------------------------------    
        public void QuickSort()
        {
            this.stepCount = 0;

            // Get a reference to the items array object
            T[] oSet = this.array.Items;

            // Start of the recursion
            recuseQuickSort(oSet, 0, this.array.ItemCount - 1, 0);

            // Replace the items using the ordered array that the algorithm has produced
            for (int i = 0; i < this.array.ItemCount; i++)
                this.array.Items[i] = oSet[i];
        }
        //--------------------------------------------------------------------------    
        public void QuickSort(CArray<T> p_oArray)
        {
            this.array = p_oArray;
            this.QuickSort();
        }
        //--------------------------------------------------------------------------    

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Data.Structures;

namespace Lib.Data.Algorithms
{
    public class CMergeSort<T>: CAlgorithmForArray<T>
    {
        //--------------------------------------------------------------------------
        public CMergeSort(): base()
        {

        }
        //--------------------------------------------------------------------------
        public CMergeSort(CArray<T> p_oArray): base(p_oArray)
        {
        }
        //--------------------------------------------------------------------------    
        protected void internalMerge(T[] p_oMergedSet, T[] p_oLeftSplit, T[] p_oRightSplit)
        {
            int nLeftItemCount = p_oLeftSplit.Length;
            int nRightItemCount = p_oRightSplit.Length;

            int i = 0, j = 0;
            int nCurrentIndex = 0;
            while ((i < nLeftItemCount) && (j < nRightItemCount))
            {
                if (compare(this.array.ComparisonBy, p_oLeftSplit[i], p_oRightSplit[j]) <= 0)
                {
                    p_oMergedSet[nCurrentIndex] = p_oLeftSplit[i];
                    i++;
                }
                else
                {
                    p_oMergedSet[nCurrentIndex] = p_oRightSplit[j];
                    j++;
                }
                nCurrentIndex++;
            }

            while (i < nLeftItemCount)
                p_oMergedSet[nCurrentIndex++] = p_oLeftSplit[i++];

            while (j < nRightItemCount)
                p_oMergedSet[nCurrentIndex++] = p_oRightSplit[j++];
        }
        //--------------------------------------------------------------------------    
        protected void recurseMergeSort(T[] p_oSet, int p_nStart, int p_nEnd, int p_nDepth)
        {
            int nSubSetItemCount = (p_nEnd - p_nStart + 1);
            if (nSubSetItemCount < 2)
                return;

            this.stepCount++;

            int nMiddleIndex = nSubSetItemCount / 2;
            int nLeftSplitItemCount = nMiddleIndex;
            int nRightSplitItemCount = nSubSetItemCount - nLeftSplitItemCount;

            // ..... Splitting .....
            // Left split
            T[] oLeftSplit = new T[nLeftSplitItemCount];
            for (int i = 0; i < nMiddleIndex; i++)
                oLeftSplit[i] = p_oSet[i];

            // Right split
            T[] oRightSplit = new T[nRightSplitItemCount];
            for (int i = nMiddleIndex; i < nSubSetItemCount; i++)
                oRightSplit[i - nMiddleIndex] = p_oSet[i];

            debugArrays("", oLeftSplit, oRightSplit, p_nDepth);

            // Recursive calls to further split the set of items
            recurseMergeSort(oLeftSplit, 0, nLeftSplitItemCount - 1, p_nDepth + 1);
            recurseMergeSort(oRightSplit, 0, nRightSplitItemCount - 1, p_nDepth + 1);

            // ..... Merging .....
            // Merge the two split sets oLeftSplit and oRightSplit into p_oSet
            internalMerge(p_oSet, oLeftSplit, oRightSplit);
            debugArray("Merge", p_oSet, nSubSetItemCount, p_nDepth);
        }
        //--------------------------------------------------------------------------    
        public void MergeSort()
        {
            this.stepCount = 0;

            // Get a reference to the items array object
            T[] oSet = this.array.Items;

            // Start of the recursion
            recurseMergeSort(oSet, 0, this.array.ItemCount - 1, 1);

            // Replace the items using the ordered array that the algorithm has produced
            for (int i = 0; i < this.array.ItemCount; i++)
                this.array.Items[i] = oSet[i];
        }
        //--------------------------------------------------------------------------     
        public void MergeSort(CArray<T> p_oArray)
        {
            this.array = p_oArray;
            this.MergeSort();
        }
        //--------------------------------------------------------------------------     

    }
}

using Lib.Data.Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Algorithms
{
    public class CBinarySearch<T> : CAlgorithmForArray<T>
    {
        //--------------------------------------------------------------------------
        public CBinarySearch() : base()
        {

        }
        //--------------------------------------------------------------------------
        public CBinarySearch(CArray<T> p_oArray) : base(p_oArray)
        {
        }
        //--------------------------------------------------------------------------
        public T? BinarySearch(CArray<T> p_oArray, T p_oSearchValue)
        {
            this.array = p_oArray;
            return this.BinarySearch(p_oSearchValue);
        }
        //--------------------------------------------------------------------------
        // Binary search algorithm
        public T? BinarySearch(T p_oSearchValue)
        {
            return recurseBinarySearch(p_oSearchValue, 0, this.array.ItemCount - 1, 1);
        }
        //--------------------------------------------------------------------------
        // This recursive method calss itself, to perform a single step of the binary search algorithm
        private T? recurseBinarySearch(T p_oSearchValue, int p_nStartIndex, int p_nEndIndex, int p_nAlgorithmStep)
        {
            T? oResult = default(T);
            if ((p_nEndIndex - p_nStartIndex >= 0) && (p_nStartIndex < this.array.ItemCount))
            {
                int nMiddleIndex = p_nStartIndex + (p_nEndIndex - p_nStartIndex) / 2;
                T oMiddleItem = this.array.Items[nMiddleIndex];

                int nComparisonResult = this.compare(this.array.ComparisonBy, oMiddleItem, p_oSearchValue);
                Debug.WriteLine($"Search step {p_nAlgorithmStep} in interval [{p_nStartIndex},{p_nEndIndex}]:"
                              + $" middle #{nMiddleIndex} '{oMiddleItem}'.CompareTo('{p_oSearchValue}') result is {nComparisonResult}");

                if (nComparisonResult > 0)
                    // In the next step it will check the middle of the left split
                    oResult = recurseBinarySearch(p_oSearchValue, p_nStartIndex, nMiddleIndex - 1, p_nAlgorithmStep + 1);
                else if (nComparisonResult < 0) // less than
                    // In the next step it will check the middle of the right split
                    oResult = recurseBinarySearch(p_oSearchValue, nMiddleIndex + 1, p_nEndIndex, p_nAlgorithmStep + 1);
                else if (nComparisonResult == 0) //equals
                    oResult = oMiddleItem;
            }
            return oResult;
        }
        //--------------------------------------------------------------------------
    }
}

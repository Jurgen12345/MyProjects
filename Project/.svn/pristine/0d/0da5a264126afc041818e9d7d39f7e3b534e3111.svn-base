using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Data.Structures;

namespace Lib.Data.Algorithms
{
    public class CSearch<T>: CAlgorithmForArray<T>
    {
        //--------------------------------------------------------------------------
        public CSearch(): base()
        {

        }
        //--------------------------------------------------------------------------
        public CSearch(CArray<T> p_oArray) : base(p_oArray)
        {
        }
        //--------------------------------------------------------------------------
        public int ExhaustiveSearch(CArray<T> p_oArray, T p_oSearchValue)
        {
            this.array = p_oArray;
            return this.ExhaustiveSearch(p_oSearchValue);
        }
        //--------------------------------------------------------------------------
        public int ExhaustiveSearch(T p_oSearchValue)
        {
            int nFoundIndex = -1;
            for (int i = 0; i < this.array.ItemCount; i++)
            {
                int nComparisonResult = this.compare(this.array.ComparisonBy, this.array.Items[i], p_oSearchValue);
                if (nComparisonResult == 0)
                {
                    nFoundIndex = i;
                    break;
                }
            }
            return nFoundIndex;
        }
        //--------------------------------------------------------------------------
        public int BinarySearch(CArray<T> p_oArray, T p_oSearchValue)
        {
            this.array = p_oArray;
            return this.BinarySearch(p_oSearchValue);
        }
        //--------------------------------------------------------------------------
        // Binary search algorithm
        public int BinarySearch(T p_oSearchValue)
        {
            IsFinished = false;
            Debug.WriteLine($"[>] Searching for {p_oSearchValue}");
            int nFoundIndex = -1;
            int nCountSteps = 0;

            int nStartIndex = 0;
            int nEndIndex = this.array.ItemCount;

            // Continue to loop until the is nothing to dichotomize
            while ((nEndIndex - nStartIndex >= 0) && (nStartIndex < this.array.ItemCount))
            {
                nCountSteps++;
                int nMiddleIndex = nStartIndex + (nEndIndex - nStartIndex) / 2;
                Debug.WriteLine($"|_ Searching in interval [{nStartIndex},{nEndIndex}] middle is {nMiddleIndex}");
                this.algorithmStep(this.array, nStartIndex, nEndIndex, nMiddleIndex, p_oSearchValue.ToString());

                int nComparisonResult = this.compare(this.array.ComparisonBy, this.array.Items[nMiddleIndex], p_oSearchValue);
                if (nComparisonResult > 0)
                {
                    Debug.WriteLine("    Search interval end moved just before middle index.");
                    nEndIndex = nMiddleIndex - 1;  // In the next step it will check the middle of the left split
                }
                else if (nComparisonResult < 0) // less than
                {
                    Debug.WriteLine("    Search interval start moved just after middle index.");
                    nStartIndex = nMiddleIndex + 1; // In the next step it will check the middle of the right split   
                }
                else if (nComparisonResult == 0) //equals
                {
                    nFoundIndex = nMiddleIndex;
                    break;
                }
            }
            Debug.WriteLine($"Search completed in {nCountSteps} steps");
            IsFinished = true;
            return nFoundIndex;
        }
        //--------------------------------------------------------------------------
    }
}

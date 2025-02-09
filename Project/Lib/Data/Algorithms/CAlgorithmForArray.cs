using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Data.Structures;

namespace Lib.Data.Algorithms
{
    // ==================================================================================================
    public class CAlgorithmForArray<T>
    {
        public bool IsFinished { get; set; }
        protected CArray<T>? array = null;
        protected int stepCount = 0;

        // [C# ADVANCED] Declaring an event trigger on which event handlers can be assigned
        public event AlgorithmStepHandler<T>? OnAlgorithmStep;

        //--------------------------------------------------------------------------
        public CAlgorithmForArray()
        {

        }
        //--------------------------------------------------------------------------
        public CAlgorithmForArray(CArray<T> p_oArray)
        {
            this.array = p_oArray;
        }
        //--------------------------------------------------------------------------
        protected string arrayToString(T[] p_oArray)
        {
            return arrayToString(p_oArray, 0, p_oArray.Length - 1);
        }
        //--------------------------------------------------------------------------
        protected string arrayToString(T[] p_oArray, int p_nStartIndex, int p_nEndIndex)
        {
            String sItems = "";
            for (int i = p_nStartIndex; i <= p_nEndIndex; i++)
            {
                if (i > 0)
                    sItems += ",";
                sItems += p_oArray[i];
            }
            return sItems;
        }
        //--------------------------------------------------------------------------
        protected void debugArray(string p_sOperation, T[] p_oSet, int p_nItemCount, int p_nDepth)
        {
            String sPrefix = $"Depth {p_nDepth} {p_sOperation}: ";
            String sItems = arrayToString(p_oSet, 0, p_nItemCount - 1);
            Debug.WriteLine($"Step #{this.stepCount}: {sPrefix}[{sItems}]");
        }
        //--------------------------------------------------------------------------    
        protected void debugArrays(string p_sOperation, T[] p_oLeft, T[] p_oRight, int p_nDepth)
        {
            String sLeftItems = arrayToString(p_oLeft);
            String sRightItems = arrayToString(p_oRight);
            String sPrefix = $"Depth {p_nDepth} {p_sOperation}:";
            Debug.WriteLine($"Step #{this.stepCount}: {sPrefix}[{sLeftItems}]  [{sRightItems}]");
        }
        //--------------------------------------------------------------------------    
        protected void debugArrayPartitions(string p_sOperation, T[] p_oSet, int p_nLeft, int p_nMiddle, int p_nRight, int p_nDepth)
        {
            String sLeftItems = arrayToString(p_oSet, p_nLeft, p_nMiddle - 1);
            String sRightItems = arrayToString(p_oSet, p_nMiddle + 1, p_nRight);
            String sPrefix = $"Depth {p_nDepth} {p_sOperation}:";
            Debug.WriteLine($"Step #{this.stepCount}: {sPrefix}[{sLeftItems}]  [{sRightItems}]");
        }
        //--------------------------------------------------------------------------
        // [OO PRINCIPLES] [POLYMORPHISM]: Overloaded method
        protected void algorithmStep(CArray<T> p_oArray,  int p_nOuterLoopIndex, int p_nInnerLoopIndex, string p_sMessage)
        {
            if (OnAlgorithmStep != null)
            {
                CAlgorithmStepInfo oStepInfo = new CAlgorithmStepInfo()
                { OuterLoopIndex = p_nOuterLoopIndex, InnerLoopIndex = p_nInnerLoopIndex, Message = p_sMessage };

                OnAlgorithmStep.Invoke(p_oArray, oStepInfo);
            }
        }
        //--------------------------------------------------------------------------
        // [OO PRINCIPLES] [POLYMORPHISM]: Overloaded method
        protected void algorithmStep(CArray<T> p_oArray, int p_nStartIndex, int p_nEndIndex, 
                                        int p_nMiddleIndex, string p_sMessage )
        {
            if (OnAlgorithmStep != null)
            {
                CAlgorithmStepInfo oStepInfo = new CAlgorithmStepInfo()
                { StartIndex = p_nStartIndex, EndIndex = p_nEndIndex,
                    MiddleIndex = p_nMiddleIndex, Message = p_sMessage };

                OnAlgorithmStep.Invoke(p_oArray, oStepInfo);
            }
        }
        //--------------------------------------------------------------------------
        // [OO PRINCIPLES] [POLYMORPHISM]
        // This form of the overloaded method compares two items using the default comparison,
        // if the class of the item supports the IComparable interface
        protected int compare(T p_oThisItem, T p_oOtherItem)
        {
            int nResult = 1;

            // Default comparison if the class of the items supports the IComparable interface
            IComparable<T>? iCurrentItem = p_oThisItem as IComparable<T>;
            if (iCurrentItem != null)
                nResult = iCurrentItem.CompareTo(p_oOtherItem);

            return nResult;
        }
        //--------------------------------------------------------------------------
        // [OO PRINCIPLES] [POLYMORPHISM]
        // This form of the overloaded method allows for comparing specific fields on the two objects
        protected int compare(IItemComparison<T>? p_iComparison, T p_oThisItem, T p_oOtherItem)
        {
            int nResult = 1;

            // Check if a helper object for specific field comparison (implements IItemComparison)
            // has been supplied to this method and use it by priority
            if (p_iComparison != null)
                nResult = p_iComparison.Compare(p_oThisItem, p_oOtherItem);
            else
                // Calls the other form of the method
                nResult = compare(p_oThisItem, p_oOtherItem);
            return nResult;
        }
        //--------------------------------------------------------------------------
    }
}

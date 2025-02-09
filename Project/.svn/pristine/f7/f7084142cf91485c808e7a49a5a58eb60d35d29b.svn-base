using Lib.Data.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Algorithms
{
    public class CAlgorithmForLinkedList<T>
    {
        public bool IsFinished { get; set; }
        protected CSinglyLinkedList<T>? list = null;

        // [C# ADVANCED] Declaring an event trigger on which event handlers can be assigned
        public event AlgorithmLLStepHandler<T>? OnAlgorithmStep;


        //--------------------------------------------------------------------------
        public CAlgorithmForLinkedList()
        {
        }
        //--------------------------------------------------------------------------
        public CAlgorithmForLinkedList(CSinglyLinkedList<T> p_oLinkedList)
        {
            this.list = p_oLinkedList;
        }
        //--------------------------------------------------------------------------
        // [OO PRINCIPLES] [POLYMORPHISM]: Overloaded method
        protected void algorithmStep(CSinglyLinkedList<T> p_oLinkedList, int p_nOuterLoopIndex, int p_nInnerLoopIndex, string p_sMessage)
        {
            if (OnAlgorithmStep != null)
            {
                CAlgorithmStepInfo oStepInfo = new CAlgorithmStepInfo()
                { OuterLoopIndex = p_nOuterLoopIndex, InnerLoopIndex = p_nInnerLoopIndex, Message = p_sMessage };

                OnAlgorithmStep.Invoke(p_oLinkedList, oStepInfo);
            }
        }
        //--------------------------------------------------------------------------
        // [OO PRINCIPLES] [POLYMORPHISM]: Overloaded method
        protected void algorithmStep(CSinglyLinkedList<T> p_oLinkedList, int p_nStartIndex, int p_nEndIndex,
                                        int p_nMiddleIndex, string p_sMessage)
        {
            if (OnAlgorithmStep != null)
            {
                CAlgorithmStepInfo oStepInfo = new CAlgorithmStepInfo()
                {
                    StartIndex = p_nStartIndex,
                    EndIndex = p_nEndIndex,
                    MiddleIndex = p_nMiddleIndex,
                    Message = p_sMessage
                };

                OnAlgorithmStep.Invoke(p_oLinkedList, oStepInfo);
            }
        }
        //--------------------------------------------------------------------------
        // [OO PRINCIPLES] [POLYMORPHISM]
        // This form of the overloaded method compares two items using the default comparison,
        // if the class of the item supports the IComparable interface
        protected int compare(CLinkedListNode<T>? p_oThisNode, T? p_oValue)
        {
            int nResult = 1;

            if ((p_oThisNode != null) && (p_oValue != null))
            { 
                // Default comparison if the class of the items supports the IComparable interface
                IComparable<T>? iThisNodeValue = p_oThisNode.Value as IComparable<T>;
                if (iThisNodeValue != null)
                    nResult = iThisNodeValue.CompareTo(p_oValue);
            }

            return nResult;
        }
        //--------------------------------------------------------------------------
        // [OO PRINCIPLES] [POLYMORPHISM]
        // This form of the overloaded method allows for comparing specific fields on the two objects
        protected int compare(IItemComparison<T>? p_iComparison, CLinkedListNode<T>? p_oThisNode, T? p_oValue)
        {
            int nResult = 1;

            // Check if a helper object for specific field comparison (implements IItemComparison)
            // has been supplied to this method and use it by priority
            if (p_iComparison != null)
            { 
                if ((p_oThisNode != null) && (p_oValue != null) && (p_oThisNode.Value != null))
                    nResult = p_iComparison.Compare(p_oThisNode.Value, p_oValue);
            }
            else
            { 
                // Calls the other form of the method
                if ((p_oThisNode != null) && (p_oValue != null))
                    nResult = compare(p_oThisNode, p_oValue);
            }
            return nResult;
        }
        //--------------------------------------------------------------------------
    }
}

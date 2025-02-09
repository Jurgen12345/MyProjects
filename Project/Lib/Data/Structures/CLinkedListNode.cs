using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    public class CLinkedListNode<T>
    {
        // ................................................................
        // This is a  value "boxed" inside a node of the linked list
        public T? Value { get; set; }
        // ................................................................
        protected CLinkedListNode<T>? next = null;
        public CLinkedListNode<T>? Next  { get { return next; } set { setNext(value); } }

        protected virtual void setNext(CLinkedListNode<T>? p_oValue)
        {
            this.next = p_oValue;               
        }
        // ................................................................        


            //--------------------------------------------------------------------------
        public CLinkedListNode()
        {
            this.Next = null;
            this.Value = default(T?); // [C#] Null for a generic type
        }
        //--------------------------------------------------------------------------
        public override string ToString()
        {
            string sResult = "";
            if (this.Value == null)
                sResult += "[null]";
            else
                sResult += $"[{this.Value.ToString()}]";

            if (this.next != null)
                if (this.next.Value == null)
                    sResult += " -> null";
                else
                    sResult += $" -> {this.next.Value.ToString()}";

            return sResult;
        }
        //--------------------------------------------------------------------------
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{

    public class CDoublyLinkedListNode<T>: CLinkedListNode<T>
    {
        // ................................................................
        new public CDoublyLinkedListNode<T>? Next
        {
            // [C#] The "as" operator, tries to cast an object to another type given
            // in the right side of the "as" expression. If the conversion is not valid
            // it will bring a null, that is used in the return statement. 
            // This is called safe typecasting.
            get { return this.next as CDoublyLinkedListNode<T>; }
            set { setNext(value); }
        }

        protected override void setNext(CLinkedListNode<T>? p_oValue)
        {
            // Removes the link to previous, in case we change this.next to another node
            CDoublyLinkedListNode<T>? oNext = this.next as CDoublyLinkedListNode<T>;
            if (oNext != null)
                oNext.previous = null;

            // Ensures the link to previous for the bi-directional link
            CDoublyLinkedListNode<T>? oValue = p_oValue as CDoublyLinkedListNode<T>;
            if (oValue != null)
                oValue.previous = this;

            // Ensures the link to next for the bi-directional link
            this.next = oValue;

        }
        // ................................................................   

        // ................................................................
        protected CDoublyLinkedListNode<T>? previous = null;
        
        public CDoublyLinkedListNode<T>? Previous
        { 
            get { return this.previous; } 
            set 
            {
                // Removes the link to next, in case we change this.previous to another node
                if (this.previous != null)
                    this.previous.next = null;

                // Ensures the link to previous for the bi-directional link
                if (value != null)
                    value.next = this;

                // Ensures the link to next for the bi-directional link
                this.previous = value;
            }
        }
        // ................................................................


        //--------------------------------------------------------------------------
        public CDoublyLinkedListNode()
        {
            this.Next = null;
            this.Previous = null;
            this.Value = default(T);
        }
        //--------------------------------------------------------------------------
        public override string ToString()
        {
            string sResult = "";

            if (this.previous != null)
                if (this.previous.Value != null)
                    sResult += $"{this.previous.Value.ToString()} <- ";
                else
                    sResult += "null <- ";
            else
                sResult += " <- ";
 
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
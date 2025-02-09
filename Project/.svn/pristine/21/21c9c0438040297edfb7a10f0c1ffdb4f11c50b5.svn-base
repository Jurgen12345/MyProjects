using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    // [INHERITANCE] This is an example of inheritance having a generic ancestor (superclass),  a generic descendant (subclass) and a type constraint for T.
    public class CArrayUnordered<T>: CArrayIterable<T> where T: IComparable<T>
    {
        //--------------------------------------------------------------------------
        public CArrayUnordered(): base() 
        { 
        }
        //--------------------------------------------------------------------------
        public CArrayUnordered(int p_nPageSize): base(p_nPageSize) 
        { 
        }
        //--------------------------------------------------------------------------
        public void Add(T p_oItem) // Just a precaution, if Add is called on this object
        {
            this.appendItem(p_oItem);
        }
        //--------------------------------------------------------------------------
        public void Append(T p_oItem)
        {
            this.appendItem(p_oItem);  // This protected method is inherited
        }
        //--------------------------------------------------------------------------
        public void Prepend(T p_oItem)
        {
            this.insertItem(0, p_oItem); // This protected method is inherited
        }
        //--------------------------------------------------------------------------
        public void Insert(int p_nIndex, T p_oItem)
        {
            // If outside of the upper array bound
            if (p_nIndex >= this.itemCount)
                // Simple append to the end with O(1) cost
                this.appendItem(p_oItem);
            else
                this.insertItem(p_nIndex, p_oItem);
        }
        //--------------------------------------------------------------------------
        // Exhaustive search algorithm
        public int Search(T p_oSearchValue)
        {
            int nFoundIndex = -1;
            for (int i = 0; i < this.itemCount; i++)
            {
                // We get interface references from objects, since they are implementing IComparable
                IComparable<T> iItem = (IComparable<T>)this.items[i];
                if (iItem.CompareTo(p_oSearchValue) == 0)
                {
                    nFoundIndex = i;
                    break;
                }
            }
            return nFoundIndex;
        }
        //--------------------------------------------------------------------------
    }
}

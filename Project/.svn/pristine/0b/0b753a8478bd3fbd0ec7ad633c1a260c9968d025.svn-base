using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    public class CHashTable<K,V>: CDictionary<K, V>
    {

        //--------------------------------------------------------------------------
        // [OOP] [INHERITANCE] Calling the constructor of CDictionary that has 2 parameters,
        // and providing values for them. The default is a pagesize of 100 and no ordering.
        public CHashTable(): base(50, false)  
        {
        }
        //--------------------------------------------------------------------------
        // [OOP] [INHERITANCE] Calling the constructor of CDictionary that has 2 parameters,
        // providing values for them. A custom pagesize and no ordering.
        public CHashTable(int p_nPageSize) : base(p_nPageSize, false)
        {
        }
        //--------------------------------------------------------------------------
        // This method should be overriden with a specific hash function in the descendand.
        protected virtual int HashFunction(K p_oKey)  // [OOP] [POLYMORPHISM] Virtual method
        {
            // [C#] Throwing an exception will forcefully terminate an executing code
            throw new NotImplementedException();
        }
        //--------------------------------------------------------------------------
        // Finds the key-value pair (dictionary entry) given its key, with O(1) cost
        public override CKeyValueEntry<K,V>? FindEntry(K p_oKey)
        {
            int nIndex = this.HashFunction(p_oKey);
            if ((nIndex >= 0) && (nIndex < this.Capacity))
                return this.items[nIndex];
            else
                return null;
        }
        //--------------------------------------------------------------------------
        // Add the new key-value pair (dictionary entry), with O(1) cost
        public override void AddEntry(CKeyValueEntry<K,V> p_oEntry)
        {
            int nIndex = this.HashFunction(p_oEntry.Key);
            if (nIndex >= Capacity)
                // [C#] Example of throwing a custom exception message
                throw new Exception("Insufficient capacity to store the item at the hash index");

            items[itemCount] = p_oEntry;
            itemCount++;
        }
        //--------------------------------------------------------------------------
        // Removes the dictionary entry for the given key, with O(1) cost.
        public override bool RemoveEntry(K p_oKey)
        {
            bool bHasDeleted = false;
            int nIndex = this.HashFunction(p_oKey);
            if ((nIndex >= 0) && (nIndex < this.Capacity))
            { 
                this.items[nIndex] = null;
                itemCount --;
                bHasDeleted = true;
            }

            return bHasDeleted;
        }
        //--------------------------------------------------------------------------
    }
}

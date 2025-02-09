using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    public class CDictionary<K,V>: CArrayIterable<CKeyValueEntry<K,V>>
    {
        // ................................................................
        // [C#] This special property is called an indexer. It allows your object to be used as an array.
        // The dictionary is an associative array, so instead of an index a key is give to access the items.
        public V? this[K p_oKey]
        {
            get
            {
                // [INDIRECT ACCESS]: We find the key-value dictionary entry for the given key and return its value
                CKeyValueEntry<K,V>? oFoundEntry = this.FindEntry(p_oKey);
                if (oFoundEntry != null)
                    return oFoundEntry.Value;
                else
                    return default(V); // [C#] Null value for generic type V
            }
            set
            {
                // [INDIRECT ACCESS]:  We ensure key-value dictionary entry for the given key and set its value
                CKeyValueEntry<K, V> oFoundEntry = this.EnsureEntry(p_oKey);
                oFoundEntry.Value = value;
            }
        }
        // ................................................................
        protected bool isOrdered = true;



        //--------------------------------------------------------------------------
        public CDictionary(): base(100)
        {
            isOrdered = true;
        }
        //--------------------------------------------------------------------------
        public CDictionary(int p_nPageSize, bool p_bIsOrdered): base(p_nPageSize)
        {
            this.isOrdered = p_bIsOrdered;
        }
        //--------------------------------------------------------------------------
        public bool ContainsKey(K p_oKey)
        {
            return FindEntry(p_oKey) != null;
        }
        //--------------------------------------------------------------------------
        // Ensures the existence of the dictionary entry for the given key and returns it.
        public CKeyValueEntry<K, V> EnsureEntry(K p_oKey)
        {
            // Check if there is an existing entry
            CKeyValueEntry<K, V>? oEntry = this.FindEntry(p_oKey);

            // If there is no entry for this key, append a new entry to the array
            if (oEntry == null)
            {
                oEntry = new CKeyValueEntry<K, V>(p_oKey);
                this.AddEntry(oEntry);
            }

            // In any case an entry will be returned to the caller of this method
            return oEntry;
        }
        //--------------------------------------------------------------------------
        // Finds the key-value pair (dictionary entry) given its key and
        // depending on the setting of IsOrdered:
        //    For ordered keys, it uses binary search, with O(logN) cost.
        //    For non-ordered keys, it uses exhaustive search, with O(N) cost.
        public virtual CKeyValueEntry<K,V>? FindEntry(K p_oKey)   // [OOP] [POLYMORPHISM] Virtual method
        {
            if (this.itemCount == 0)
                return null;
            else if (this.isOrdered)
                return binarySearch(p_oKey);
            else
                return exhaustiveSearch(p_oKey);
        }
        //--------------------------------------------------------------------------
        // Add the new key-value pair (dictionary entry) depending on the setting isOrdered:
        //    For ordered keys, it insert is at the proper index, with O(N) cost.
        //    For non-ordered keys, it appends it at the end, with O(1) cost.
        public virtual void AddEntry(CKeyValueEntry<K,V> p_oEntry)  // [OOP] [POLYMORPHISM] Virtual method
        {
            if (this.isOrdered)
            {
                // First part of this method is to determine the insertion position.
                int nInsertionPos = 0;
                while (nInsertionPos <= this.itemCount - 1)
                {
                    // Compare item at current position if it is greater in order that the given p_sItem
                    CKeyValueEntry<K, V> oKVPair = this.items[nInsertionPos];
                    IComparable<K>? iCurrentKey = oKVPair.Key as IComparable<K>;
                    if (iCurrentKey.CompareTo(p_oEntry.Key) > 0)
                        // If there is an item that is higher in alphabetic order we stop the loop to insert here
                        break;

                    nInsertionPos++;
                }

                // Instead of writing the same insertion logic again, we re-use it through inheritance
                this.insertItem(nInsertionPos, p_oEntry);
            }
            else
                // Append to the unordered array
                this.appendItem(p_oEntry);
        }
        //--------------------------------------------------------------------------
        // Removes the dictionary entry for the given key.
        public virtual bool RemoveEntry(K p_oKey)  // [OOP] [POLYMORPHISM] Virtual method
        {
            bool bHasDeleted = false;
            for(int nIndex = 0; nIndex < this.itemCount; nIndex ++)
            {
                CKeyValueEntry<K,V> oKVPair = this.items[nIndex];
                IComparable<K>? iCurrentKey = oKVPair.Key as IComparable<K>;
                if (iCurrentKey.CompareTo(p_oKey) == 0)
                {
                    this.deleteItem(nIndex);
                    bHasDeleted = true;
                    break;
                }
            }
            return bHasDeleted;
        }
        // ................................................................
        // Fills the destination array with the values of the dictionary keys
        public void GetKeysInto(CArrayIterable<K> p_oDestArray)
        {
            p_oDestArray.Clear();
            for (int i = 0; i < this.itemCount; i++)
            {
                CKeyValueEntry<K,V> oKeyValueEntry = this.items[i];
                K oKey = oKeyValueEntry.Key;
                p_oDestArray.appendItem(oKey);
            }
        }
        // ................................................................
        // Fills the destination array with the values of the dictionary keys
        public void GetValuesInto(CArrayIterable<V> p_oDestArray)
        {
            p_oDestArray.Clear();
            for (int i = 0; i < this.itemCount; i++)
            {
                CKeyValueEntry<K, V> oKeyValueEntry = this.items[i];
                V oValue = oKeyValueEntry.Value;
                p_oDestArray.appendItem(oValue);
            }
        }
        //--------------------------------------------------------------------------
        // Simple exhaustive search to find the dictionary entry for a given key
        protected CKeyValueEntry<K,V>? exhaustiveSearch(K p_oKey)
        {
            CKeyValueEntry<K,V>? oFoundEntry = null;
            for (int nIndex = 0; nIndex < this.itemCount; nIndex++)
            {
                CKeyValueEntry<K, V> oKVPair = this.items[nIndex];
                IComparable<K>? iCurrentKey = oKVPair.Key as IComparable<K>;
                if (iCurrentKey.CompareTo(p_oKey) == 0)
                {
                    oFoundEntry = oKVPair;
                    break;
                }
            }
            return oFoundEntry;
        }
        //--------------------------------------------------------------------------
        // Binary search implementation with recursion.
        protected CKeyValueEntry<K,V>? binarySearch(K p_oKey)
        {
            return recurseBinarySearch(p_oKey, 0, this.itemCount - 1, 1);
        }
        //--------------------------------------------------------------------------
        // This recursive method calss itself, to perform a single step of the binary search algorithm
        private CKeyValueEntry<K,V>? recurseBinarySearch(K p_oKey, int p_nStartIndex, int p_nEndIndex, int p_nAlgorithmStep)
        {
            CKeyValueEntry<K,V>? oResult = null;
            if ((p_nEndIndex - p_nStartIndex  >= 0) && (p_nStartIndex < this.itemCount))
            { 
                int nMiddleIndex = p_nStartIndex + (p_nEndIndex - p_nStartIndex) / 2;
                CKeyValueEntry<K, V> oMiddleItem = this.items[nMiddleIndex];
                IComparable<K>? iMiddleItemKey = oMiddleItem.Key as IComparable<K>;
                int nComparisonResult = iMiddleItemKey.CompareTo(p_oKey);

                Debug.WriteLine($"Search step {p_nAlgorithmStep} in interval [{p_nStartIndex},{p_nEndIndex}]:"
                              + $" middle #{nMiddleIndex} '{oMiddleItem.Key}'.CompareTo('{p_oKey}') result is {nComparisonResult}");

                if (nComparisonResult > 0)
                    // In the next step it will check the middle of the left split
                    oResult = recurseBinarySearch(p_oKey, p_nStartIndex, nMiddleIndex - 1, p_nAlgorithmStep + 1);
                else if (nComparisonResult < 0) // less than
                    // In the next step it will check the middle of the right split
                    oResult = recurseBinarySearch(p_oKey, nMiddleIndex + 1, p_nEndIndex, p_nAlgorithmStep + 1);
                else if (nComparisonResult == 0) //equals
                    oResult = oMiddleItem;
            }
            return oResult;
        }
        //--------------------------------------------------------------------------
        // This method will help us display the data structure in the UI
        public override string ToString()
        {
            String sResult = "{\r\n    ";
            for (int i = 0; i < this.itemCount; i++)
            {
                if (i > 0)
                {
                    sResult += ",\r\n    ";
                }
                CKeyValueEntry<K,V> oEntry = this.items[i];

                sResult += $"\"{oEntry.Key}\" : \"{oEntry.Value}\"";
            }
            sResult += "\r\n}";
            return sResult;
        }
        //--------------------------------------------------------------------------
    }
}

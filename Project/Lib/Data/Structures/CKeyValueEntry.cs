using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    public class CKeyValueEntry<K,V>
    {
        public K  Key { get; set; }
        public V? Value { get;set; } = default(V); // [C#] Null for generic type V
        
        //--------------------------------------------------------------------------
        public CKeyValueEntry(K p_oKey)
        {
            this.Key = p_oKey;
        }
        //--------------------------------------------------------------------------
    }
}

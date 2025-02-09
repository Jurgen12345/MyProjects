
package data;

public class CKeyValueEntry<K, V>
{
    public K Key = null;
    public V Value = null;
    public int Index = -1;
    
    //--------------------------------------------------------------------------
    public CKeyValueEntry()
    {
    }
    //--------------------------------------------------------------------------
    public CKeyValueEntry(K p_oKey) 
    {
        this.Key = p_oKey;
    }
    //--------------------------------------------------------------------------
    
    
}

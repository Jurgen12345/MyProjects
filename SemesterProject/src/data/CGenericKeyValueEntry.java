package data;

public class CGenericKeyValueEntry<K, V>
{
    public K Key = null;
    public V Value = null;
    public int Index = -1;
    
    //--------------------------------------------------------------------------
    public CGenericKeyValueEntry()
    {
    }
    //--------------------------------------------------------------------------
    public CGenericKeyValueEntry(K p_oKey) 
    {
        this.Key = p_oKey;
    }
    //--------------------------------------------------------------------------
}

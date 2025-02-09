package data;

public class CKeyIntValueStringEntry
{
    public int                      Key;
    public String                   Value = null;
    public int                      Index;
    public CKeyIntValueStringEntry  Next;
    
    //--------------------------------------------------------------------------
    public CKeyIntValueStringEntry()
    {
    }
    //--------------------------------------------------------------------------
    public CKeyIntValueStringEntry(int p_oKey) 
    {
        this.Key = p_oKey;
    }
    //--------------------------------------------------------------------------
    
    
}

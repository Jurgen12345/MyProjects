package data;

public class CGenericDictStringKey<V> extends CGenericArray<CGenericKeyValueEntry<String,V>>
{
    private boolean isOrdered = true;
    
    //--------------------------------------------------------------------------
    public V getValue(String p_sKey) 
    {
        // We find the key-value dictionary entry from the given key
        CGenericKeyValueEntry<String,V> oFoundEntry = this.FindEntry(p_sKey);
        if (oFoundEntry != null)
            return oFoundEntry.Value;
        else
            return null;
    }
    // ................................................
    public void setValue(String p_sKey, V p_oValue) 
    {
        // We ensure the existence of the key-value dictionary entry for the given key
        CGenericKeyValueEntry<String,V> oEntry = this.EnsureEntry(p_sKey);
        oEntry.Value = p_oValue;
    }
    //--------------------------------------------------------------------------
    public CStringArray getKeys()
    {
        CStringArray oKeys = new CStringArray(this.pageSize);
        for (int i = 0; i < this.itemCount; i++)
            oKeys.Append(this.getItem(i).Key);
        return oKeys;
    }
    //--------------------------------------------------------------------------
    
    
    
    //--------------------------------------------------------------------------
    public CGenericDictStringKey() 
    {
        super(1024);
        this.isOrdered = true;
    }
    //--------------------------------------------------------------------------
    public CGenericDictStringKey(boolean p_bIsOrdered) 
    {
        super(1024);
        this.isOrdered = p_bIsOrdered;
    }    
    //--------------------------------------------------------------------------
    public CGenericDictStringKey(int p_nPageSize, boolean p_bIsOrdered) 
    {
        super(p_nPageSize);
        this.isOrdered = p_bIsOrdered;
    }
    //--------------------------------------------------------------------------
    public CGenericKeyValueEntry<String,V> FindEntry(String p_sKey) 
    {
        if (this.itemCount == 0)
            return null;
        else if (this.isOrdered)
        {
            System.out.println("----- Searching for key [" + p_sKey + "] ------");
            return recurseBinarySearch(p_sKey, 0, this.itemCount - 1, 1);
        }
        else
            return exhaustiveSearch(p_sKey);
    }
    //--------------------------------------------------------------------------
    // Simple exhaustive search to find the dictionary entry for a given key
    public CGenericKeyValueEntry<String,V> exhaustiveSearch(String p_sKey) 
    {
        CGenericKeyValueEntry<String,V> oFoundEntry = null;
        CGenericKeyValueEntry<String,V> oEntry;
        for(int i = 0; i < this.itemCount; i++)
        {
            oEntry = this.getItem(i);
            if(oEntry.Key.equals(p_sKey))
            {   oFoundEntry = oEntry;
                break;
            }
        }
        return oFoundEntry;
    }
    //--------------------------------------------------------------------------
    public CGenericKeyValueEntry<String,V> recurseBinarySearch(String p_sKey, 
        int p_nStartIndex, int p_nEndIndex, int p_nAlgorithmStep) 
    {        
        CGenericKeyValueEntry<String,V> oResult = null;

        int nMiddleIndex = p_nStartIndex +(p_nEndIndex - p_nStartIndex) / 2;  
        CGenericKeyValueEntry<String,V> oEntry = this.getItem(nMiddleIndex);
        
        System.out.println("Search step " + p_nAlgorithmStep + " in interval [" + p_nStartIndex + "," + p_nEndIndex + "]"
                            +" key at index " + nMiddleIndex + " is ["+oEntry.Key + "]");
        
        if (p_nEndIndex - p_nStartIndex < 0)
            oResult = null;    // no more split can be done -> break the recursion
        else if (oEntry.Key.compareTo(p_sKey) == 0)  // middle ite is equal
        {
            oResult = oEntry;  // found -> break the recursion 
            // Updates found result with the current index in the ordered array (has been changed since addition)
            oResult.Index = nMiddleIndex; 
        }
        else if (p_nEndIndex - p_nStartIndex == 0)   
            oResult = null;    // not found in single item interval -> break the recursion
        else if (oEntry.Key.compareTo(p_sKey) > 0)   
        {   // Recurse to search the part that contains lower in order items
            if ((nMiddleIndex - p_nStartIndex - 1) == 0)
                // one item search interval [start, start].
                oResult = recurseBinarySearch(p_sKey, p_nStartIndex, p_nStartIndex
                                                , p_nAlgorithmStep + 1);
            else
                // search inteval will be [start, middle).
                oResult = recurseBinarySearch(p_sKey, p_nStartIndex, nMiddleIndex - 1
                                                , p_nAlgorithmStep + 1);
        }
        else if (oEntry.Key.compareTo(p_sKey) < 0) 
        {   // Recurse to search the part that contains higher in order items
            if ((p_nEndIndex - nMiddleIndex - 1) == 0)
                // one item search interval [end, end].
                oResult = recurseBinarySearch(p_sKey, p_nEndIndex, p_nEndIndex
                                                , p_nAlgorithmStep + 1);
            else
                // search inteval will be (middle, end].
                oResult = recurseBinarySearch(p_sKey, nMiddleIndex + 1, p_nEndIndex
                                                , p_nAlgorithmStep + 1);
        }
        
        return oResult;
    }
    //--------------------------------------------------------------------------
    // Using the search algorith to return the index of the key inside the dictionary
    public int IndexOf(String p_sKey)  
    {
        CGenericKeyValueEntry<String,V> oEntry = this.FindEntry(p_sKey);
        return oEntry.Index;
    }    
    //--------------------------------------------------------------------------
    public void AddEntry(CGenericKeyValueEntry<String,V> p_oEntry)
    {
                   
        if (this.isOrdered)
        {
            CGenericKeyValueEntry<String,V> oCurrentEntry = null;
            int nInsertionPos = 0;
            while(nInsertionPos <= this.itemCount -1)
            {
               oCurrentEntry = this.getItem(nInsertionPos);
               // Compare the key of the current entry with the key of the given one
               // If it is higher in order we stop the loop to insert here
               if (oCurrentEntry.Key.compareTo(p_oEntry.Key) > 0)
                   break;
               nInsertionPos ++;    
            }
            this.insert(nInsertionPos, p_oEntry);            
        }
        else
        {
            p_oEntry.Index = this.itemCount; 
            // Append to the unordered array
            this.append(p_oEntry);   
        }
    }
    //--------------------------------------------------------------------------
    // Ensures the existence of the dictionary entry for the given key and returns it
    public CGenericKeyValueEntry<String,V> EnsureEntry(String p_sKey) 
    {
        // Check if there is an existing entry
        CGenericKeyValueEntry<String,V> oEntry = this.FindEntry(p_sKey);
        
        // If there is no entry for this key, append a new entry to the array
        if (oEntry == null)
        {
            oEntry = new CGenericKeyValueEntry<String,V>(p_sKey);
            this.AddEntry(oEntry);
        }
        
        // In any case an entry will be returned to the caller of this method
        return oEntry;
    }
    //--------------------------------------------------------------------------
    public boolean RemoveEntry(String p_sKey)
    {
        int nFoundIndex = this.IndexOf(p_sKey);
        if (nFoundIndex != -1)
        {    
            this.delete(nFoundIndex);
            return true;
        }
        else
            return false;
    }
    //--------------------------------------------------------------------------
    // This method will help us display the data structure in the UI
    @Override
    public String toString()
    {
        String sResult = "{\r\n    ";
        for(int i=0; i < this.itemCount; i++)
        {
            if(i>0)
            {
                sResult += ",\r\n    ";
            }
            CGenericKeyValueEntry<String,V> oEntry = this.getItem(i);
            
            sResult += "\"" + oEntry.Key + "\" :" + "\"" + oEntry.Value.toString() + "\"";
        }
        sResult += "\r\n}";
        return sResult;
    }    
    //--------------------------------------------------------------------------
    
    
    
}

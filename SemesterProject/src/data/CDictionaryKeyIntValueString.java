package data;

public class CDictionaryKeyIntValueString extends CGenericArray<CKeyIntValueStringEntry>
{
    private boolean isOrdered = true;
    
    //--------------------------------------------------------------------------
    public String getValue(int p_sKey) 
    {
        // We find the key-value dictionary entry from the given key.
        // The time complexity depends on the search algorithm inside the FindEntry() method.
        // It is O(n) for exhaustive, or O(logn) for binary search.
        CKeyIntValueStringEntry oFoundEntry = this.FindEntry(p_sKey);
        if (oFoundEntry != null)
            return oFoundEntry.Value;
        else
            return null;
    }
    // ................................................
    public void setValue(int p_sKey, String p_oValue) 
    {
        // We ensure the existence of the key-value dictionary entry for the given key
        CKeyIntValueStringEntry oEntry = this.EnsureEntry(p_sKey);
        oEntry.Value = p_oValue;
    }
    //--------------------------------------------------------------------------
   /* public CArrayInteger getKeys()
    {
        CArrayInteger oKeys = new CArrayInteger(this.pageSize);
        for (int i = 0; i < this.itemCount; i++)
            oKeys.Append(this.getItem(i).Key);
        return oKeys;
    }
    //--------------------------------------------------------------------------
    */
    
    
    //--------------------------------------------------------------------------
    public CDictionaryKeyIntValueString() 
    {
        super(1024);
        this.isOrdered = true;
    }
    //--------------------------------------------------------------------------
    public CDictionaryKeyIntValueString(boolean p_bIsOrdered) 
    {
        super(1024);
        this.isOrdered = p_bIsOrdered;
    }    
    //--------------------------------------------------------------------------
    public CDictionaryKeyIntValueString(int p_nPageSize, boolean p_bIsOrdered) 
    {
        super(p_nPageSize);
        this.isOrdered = p_bIsOrdered;
    }
    //--------------------------------------------------------------------------
    public CKeyIntValueStringEntry FindEntry(int p_sKey) 
    {
        if (this.itemCount == 0)
            return null;
        else if (this.isOrdered)
        {   // If we keep the keys in an ordered array then search has O(logn) complexity
            System.out.println("----- Searching for key [" + p_sKey + "] ------");
            return recurseBinarySearch(p_sKey, 0, this.itemCount - 1, 1);
        }
        else
            // If we keep an unordered array of keys then exhaustive search has O(n) complexity
            return exhaustiveSearch(p_sKey);
    }
    //--------------------------------------------------------------------------
    // Simple exhaustive search to find the dictionary entry for a given key
    public CKeyIntValueStringEntry exhaustiveSearch(int p_sKey) 
    {
        CKeyIntValueStringEntry oFoundEntry = null;
        CKeyIntValueStringEntry oEntry;
        for(int i = 0; i < this.itemCount; i++)
        {
            oEntry = this.getItem(i);
            if(oEntry.Key == p_sKey)
            {   oFoundEntry = oEntry;
                break;
            }
        }
        return oFoundEntry;
    }
    //--------------------------------------------------------------------------
    // Recursive implementation of the binary search algorithm
    public CKeyIntValueStringEntry recurseBinarySearch(int p_sKey, 
        int p_nStartIndex, int p_nEndIndex, int p_nAlgorithmStep) 
    {        
        CKeyIntValueStringEntry oResult = null;

        int nMiddleIndex = p_nStartIndex +(p_nEndIndex - p_nStartIndex) / 2;  
        CKeyIntValueStringEntry oEntry = this.getItem(nMiddleIndex);
        
        System.out.println("Search step " + p_nAlgorithmStep + " in interval [" + p_nStartIndex + "," + p_nEndIndex + "]"
                            +" key at index " + nMiddleIndex + " is ["+oEntry.Key + "]");
        
        if (p_nEndIndex - p_nStartIndex < 0)
            oResult = null;    // no more split can be done -> break the recursion
        else if (oEntry.Key == p_sKey)  // middle item is equal
        {
            oResult = oEntry;  // found -> break the recursion 
            // Updates found result with the current index in the ordered array (has been changed since addition)
            oResult.Index = nMiddleIndex; 
        }
        else if (p_nEndIndex - p_nStartIndex == 0)   
            oResult = null;    // not found in single item interval -> break the recursion
        else if (oEntry.Key > p_sKey)   
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
        else if (oEntry.Key < p_sKey) 
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
    public int IndexOf(int p_sKey)  
    {
        CKeyIntValueStringEntry oEntry = this.FindEntry(p_sKey);
        return oEntry.Index;
    }    
    //--------------------------------------------------------------------------
    public void AddEntry(CKeyIntValueStringEntry p_oEntry)
    {
                   
        if (this.isOrdered)
        {
            CKeyIntValueStringEntry oCurrentEntry = null;
            int nInsertionPos = 0;
            while(nInsertionPos <= this.itemCount -1)
            {
               oCurrentEntry = this.getItem(nInsertionPos);
               // Compare the key of the current entry with the key of the given one
               // If it is higher in order we stop the loop to insert here
               if (oCurrentEntry.Key > p_oEntry.Key)
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
    public CKeyIntValueStringEntry EnsureEntry(int p_sKey) 
    {
        // Check if there is an existing entry
        CKeyIntValueStringEntry oEntry = this.FindEntry(p_sKey);
        
        // If there is no entry for this key, append a new entry to the array
        if (oEntry == null)
        {
            oEntry = new CKeyIntValueStringEntry(p_sKey);
            this.AddEntry(oEntry);
        }
        
        // In any case an entry will be returned to the caller of this method
        return oEntry;
    }
    //--------------------------------------------------------------------------
    public boolean RemoveEntry(int p_sKey)
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
            CKeyIntValueStringEntry oEntry = this.getItem(i);
            
            sResult += "\"" + Integer.toString(oEntry.Key) + "\" :" + "\"" 
                        + oEntry.Value.toString() + "\"";
        }
        sResult += "\r\n}";
        return sResult;
    }    
    //--------------------------------------------------------------------------
    
    
    
}

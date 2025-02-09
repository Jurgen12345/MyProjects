package data;

public class COrderedStringArray extends CStringArray 
{
    //--------------------------------------------------------------------------
    public COrderedStringArray(int p_nCapacity) 
    {
        super(p_nCapacity);
    }
    //--------------------------------------------------------------------------
    public void Add(String p_sItem)
    {
         int nInsertionPos = 0;
         while(nInsertionPos <= this.itemCount -1)
         {
            // Compare item at current position this.items[nInsertionPos] > p_sItem
            // If there is an item that is higher in alphabetic order we stop the loop to insert here
            if (this.items[nInsertionPos].compareTo(p_sItem) > 0)
                break;
            nInsertionPos ++;    
         }
         
         // Instead of writing the same insertion logic again, we re-use it 
         // through inheritance, and the method Insert that was defined in CStringArray
         this.Insert(nInsertionPos, p_sItem);
    }
    //--------------------------------------------------------------------------
    // Binary search algorithm
    public int FastSearch(String p_sSearchValue)
    {
        int nFoundIndex = -1;
        int nCountSteps = 0;

        int nStartIndex = 0;
        int nEndIndex   = this.itemCount;
        int nMiddleIndex;
        
        // Continue to loop until the is nothing to dichotomize
        while(nEndIndex - nStartIndex >= 0)
        {   
            nCountSteps++;
            nMiddleIndex = nStartIndex + (nEndIndex - nStartIndex) / 2;  
            if (this.items[nMiddleIndex].compareTo(p_sSearchValue) == 0) //equals
            {
                nFoundIndex = nMiddleIndex;
                break;                
            }
            else if (nEndIndex - nStartIndex == 0)
            {
                nFoundIndex = -1;  // Not found in the single item searched
                break;
            }
            else if (this.items[nMiddleIndex].compareTo(p_sSearchValue) > 0) 
                    nEndIndex = nMiddleIndex - 1;  // In the next step it will check the middle of the left split
            else if (this.items[nMiddleIndex].compareTo(p_sSearchValue) < 0) 
                    nStartIndex = nMiddleIndex + 1; // In the next step it will check the middle of the right split   

        }
        System.out.println("Search completed in " + nCountSteps + " steps");
        return nFoundIndex;
    }    
    
}

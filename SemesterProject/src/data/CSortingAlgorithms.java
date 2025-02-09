package data;


public class CSortingAlgorithms 
{
    //--------------------------------------------------------------------------
    public static void BubbleSort(CStringArray p_oArray)
    {
        for(int nCurrentIndex = 1; nCurrentIndex < p_oArray.itemCount; nCurrentIndex++)
        {
            Boolean bHasSwapped = false;
            for(int j = 0; j < (p_oArray.itemCount - nCurrentIndex); j++)
            {
                String sCurrentItem = p_oArray.getItem(j);
                String sNextItem    = p_oArray.getItem(j+1);
                // Comparing items in order
                if (sCurrentItem.compareTo(sNextItem) > 0)
                {   // Swapping items
                    p_oArray.items[j]   = sNextItem;
                    p_oArray.items[j+1] = sCurrentItem;
                    bHasSwapped = true;
                }
            }
            if (!bHasSwapped)
                break;            
        }
    };    
    //--------------------------------------------------------------------------    
    public static void InsertionSort(CStringArray p_oArray)
    {
        int nCurrentIndex = 1;
        while (nCurrentIndex < p_oArray.itemCount)
        {   String sCurrentItem = p_oArray.getItem(nCurrentIndex);
            // Find insert index and move the items in the same loop
            int j = nCurrentIndex - 1;
            while (j >= 0)
            {   String sPrevItem = p_oArray.getItem(j);
                // If one of the previous items is lower in order than the current
                // this is the insert position
                if (sPrevItem.compareTo(sCurrentItem) < 0) 
                    break;
                // Moving items to make space for insertion
                p_oArray.items[j+1] = sPrevItem;
                j--;
            } 
            // The insert position is 0 if the loop finishes normally or other value due to a break
            p_oArray.items[j+1] = sCurrentItem;
            nCurrentIndex++;
        }
    }
    //--------------------------------------------------------------------------    
    private static void debugMerge(String[] p_oSet, int p_nDepth)
    {
        String sPrefix = "Depth " + p_nDepth + " Merge: ";
        
        String sItems = "";
        for(int i = 0; i < p_oSet.length; i++)
        {
            if (i > 0)
                sItems += ",";
            sItems += p_oSet[i];
        }
        
        System.out.println(sPrefix + "[" + sItems + "]");
    }
    //--------------------------------------------------------------------------    
    private static void debugSplits(String[] p_oLeft, String[] p_oRight, int p_nDepth)
    {
        String sPrefix = "Depth " + p_nDepth + ": ";
        
        String sLeftItems = "";
        for(int i = 0; i < p_oLeft.length; i++)
        {
            if (i > 0)
                sLeftItems += ",";
            sLeftItems += p_oLeft[i];
        }
        
        String sRightItems = "";
        for(int i = 0; i < p_oRight.length; i++)
        {
            if (i > 0)
                sRightItems += ",";
            sRightItems += p_oRight[i];
        }
        
        System.out.println(sPrefix + "[" + sLeftItems + "]  [" + sRightItems + "]");
        
    }
    //--------------------------------------------------------------------------    
    public static void internalMerge(String[] p_oSet, String[] p_oLeftSplit, String[] p_oRightSplit)
    {   int nLeftItemCount = p_oLeftSplit.length;
        int nRightItemCount = p_oRightSplit.length;
        
        int i = 0, j = 0; 
        int nCurrentIndex = 0;
        while ((i < nLeftItemCount) && (j < nRightItemCount)) 
        {   
            if (p_oLeftSplit[i].compareTo(p_oRightSplit[j]) <= 0) 
            {   
                p_oSet[nCurrentIndex] = p_oLeftSplit[i];   
                i++;
            }
            else 
            {   
                p_oSet[nCurrentIndex] = p_oRightSplit[j];
                j++;
            }
            nCurrentIndex++;
        }

        //JAVA: This is an assignment that is performed with the current values of
        // nCurrentIndex and i, and afterwards it increased their values by 1.
        while (i < nLeftItemCount) 
            p_oSet[nCurrentIndex++] = p_oLeftSplit[i++]; 

        while (j < nRightItemCount) 
            p_oSet[nCurrentIndex++] = p_oRightSplit[j++];
    }        
    //--------------------------------------------------------------------------    
    public static void internalMergeSort(String[] p_oSet, int p_nStart, int p_nEnd, int p_nDepth)
    {
        int nSubSetItemCount = (p_nEnd - p_nStart + 1);

        if (nSubSetItemCount < 2) 
            return;

        int nMiddleIndex = nSubSetItemCount / 2;
        int nLeftSplitItemCount  = nMiddleIndex;
        int nRightSplitItemCount = nSubSetItemCount - nLeftSplitItemCount;
        
        // Left split
        String[] oLeftSplit = new String[nLeftSplitItemCount];
        for (int i = 0; i < nMiddleIndex; i++) 
            oLeftSplit[i] = p_oSet[i];
        
        // Right split
        String[] oRightSplit = new String[nRightSplitItemCount];        
        for (int i = nMiddleIndex; i < nSubSetItemCount; i++) 
            oRightSplit[i - nMiddleIndex] = p_oSet[i];
        
        debugSplits(oLeftSplit, oRightSplit, p_nDepth);
        
        // Recursive calls to further split the set of items
        internalMergeSort(oLeftSplit , 0, nLeftSplitItemCount - 1, p_nDepth + 1);
        internalMergeSort(oRightSplit, 0, nRightSplitItemCount - 1, p_nDepth + 1);
        // Merge the two split sets oLeftSplit and oRightSplit into p_oSet
        internalMerge(p_oSet, oLeftSplit, oRightSplit);       
        debugMerge(p_oSet, p_nDepth);
    }
    //--------------------------------------------------------------------------    
    public static void MergeSort(CStringArray p_oArray)
    {
        String[] oSet = p_oArray.getArray(); 

        internalMergeSort(oSet, 0, p_oArray.itemCount - 1, 1);
        
        for(int i=0; i< p_oArray.itemCount; i++)
            p_oArray.items[i] = oSet[i];
    }
    //--------------------------------------------------------------------------    
    

     public static void internalMergeLong(long[] p_oSet, long[] p_oLeftSplit, long[] p_oRightSplit)
    {   int nLeftItemCount = p_oLeftSplit.length;
        int nRightItemCount = p_oRightSplit.length;
        
        int i = 0, j = 0; 
        int nCurrentIndex = 0;
        while ((i < nLeftItemCount) && (j < nRightItemCount)) 
        {   
            if (p_oLeftSplit[i] > p_oRightSplit[j] ) 
            {   
                p_oSet[nCurrentIndex] = p_oLeftSplit[i];   
                i++;
            }
            else 
            {   
                p_oSet[nCurrentIndex] = p_oRightSplit[j];
                j++;
            }
            nCurrentIndex++;
        }

        //JAVA: This is an assignment that is performed with the current values of
        // nCurrentIndex and i, and afterwards it increased their values by 1.
        while (i < nLeftItemCount) 
            p_oSet[nCurrentIndex++] = p_oLeftSplit[i++]; 

        while (j < nRightItemCount) 
            p_oSet[nCurrentIndex++] = p_oRightSplit[j++];
    }
    


public static void internalMergeSortLong(long[] p_oSet, int p_nStart, int p_nEnd, int p_nDepth)
    {
        int nSubSetItemCount = (p_nEnd - p_nStart + 1);

        if (nSubSetItemCount < 2) 
            return;

        int nMiddleIndex = nSubSetItemCount / 2;
        int nLeftSplitItemCount  = nMiddleIndex;
        int nRightSplitItemCount = nSubSetItemCount - nLeftSplitItemCount;
        
        // Left split
        long[] oLeftSplit = new long[nLeftSplitItemCount];
        for (int i = 0; i < nMiddleIndex; i++) 
            oLeftSplit[i] = p_oSet[i];
        
        // Right split
        long[] oRightSplit = new long[nRightSplitItemCount];        
        for (int i = nMiddleIndex; i < nSubSetItemCount; i++) 
            oRightSplit[i - nMiddleIndex] = p_oSet[i];
        
        //debugSplits(oLeftSplit, oRightSplit, p_nDepth);
        
        // Recursive calls to further split the set of items
        internalMergeSortLong(oLeftSplit , 0, nLeftSplitItemCount - 1, p_nDepth + 1);
        internalMergeSortLong(oRightSplit, 0, nRightSplitItemCount - 1, p_nDepth + 1);
        // Merge the two split sets oLeftSplit and oRightSplit into p_oSet
        internalMergeLong(p_oSet, oLeftSplit, oRightSplit);       
        //debugMerge(p_oSet, p_nDepth);
    }

  public static void MergeSortLong(CLongArray p_oArray)
    {
        long[] oSet = p_oArray.getArray();

        internalMergeSortLong(oSet, 0, p_oArray.itemCount - 1, 1);
        
        for(int i=0; i< p_oArray.itemCount; i++)
            p_oArray.items[i] = oSet[i];
    }

}
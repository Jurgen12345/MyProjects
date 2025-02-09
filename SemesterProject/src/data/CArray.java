package data;

public class CArray
{
    
    //--------------------------------------------------------------------------
    protected int itemCount = 0; // We make this field protected so it can be used by descendants.
    // ................................................
    public int getItemCount()  {
        return this.itemCount;
    }
    //--------------------------------------------------------------------------
    protected String[] items; // We make this field protected so it can be used by descendants.
    // ................................................
    public String getItem(int index) {
        return this.items[index];
    }
    // ................................................
    public void setItem(int index, String items) {
        this.items[index] = items;
    }
    //--------------------------------------------------------------------------
    private int pages;
    private int pageSize;
    private int capacity; // This field remains private, so descendands are not allowed to modify it
    // ................................................
    public int getCapacity() 
    {
        return capacity;
    }    
    //--------------------------------------------------------------------------
    
    
    
    //--------------------------------------------------------------------------
    public CArray()
    {
    }
    //--------------------------------------------------------------------------
    public CArray(int p_nPageSize) 
    {
        this.pageSize = p_nPageSize;
        this.pages    = 1;
        this.capacity = pages * pageSize;

        this.items = new String[this.capacity];
        System.out.println("Created array with capacity to hold " + capacity + " items");
    }
    //--------------------------------------------------------------------------
    private void expand()
    {
        // Increase the pages (thus the capacity) and create a new array object
        this.pages ++;
        this.capacity = pages * pageSize;
        String[] newArray = new String[this.capacity];
        
        // Copy all the items of the existing array object to the new array object. Costs O(n)
        System.arraycopy(this.items, 0, newArray, 0, this.items.length);
        
        // The reference is replace to point to the new array object, the old array object is flagged as garbage.
        this.items = newArray;
        
        System.out.println("Expanding array capacity to hold " + capacity + " items");
    }
    //--------------------------------------------------------------------------
    public void Clear()
    {
        // Reset the item count to zero, the page count to 1 and creatse a new empty array
        this.itemCount = 0;
        this.pages    = 1;
        this.capacity = pages * pageSize;

        this.items = new String[this.capacity];
        System.out.println("Emptied array the new capacity can hold " + capacity + " items");
    }
    //--------------------------------------------------------------------------
    protected void append(String p_sItem)
    {
        if (itemCount >= capacity)
            expand();
            
        items[itemCount] = p_sItem;
        itemCount++;
        
    }
    //--------------------------------------------------------------------------
    protected void moveItemsForInsert(int p_nInsertPosition)
    {
        for(int i = this.itemCount - 1; i >= p_nInsertPosition; i--)
            this.items[i+1] = this.items[i];

        items[p_nInsertPosition] = null;
    }    
    //--------------------------------------------------------------------------
    protected void insert(int p_nIndex, String p_sItem)
    {
        // If outside of the upper array bound
        if (p_nIndex >= this.itemCount)
            // Simple append to the end with O(1) cost
            this.append(p_sItem);
        else
        {
            if (itemCount >= capacity)
                expand();            
            
            // Move items to insert at p_nIndex with O(n) cost
            this.moveItemsForInsert(p_nIndex);
            items[p_nIndex] = p_sItem;
            this.itemCount++;
        }
    }
    //--------------------------------------------------------------------------
    protected void deleteFirstItem()
    {
        this.delete(0);
    }
    //--------------------------------------------------------------------------
    protected void deleteLastItem()
    {
        items[itemCount - 1] = null;
        itemCount--;
    }
    //--------------------------------------------------------------------------
    protected void delete(int p_nIndex)  
    {
        // For the last item runs a simple logic with O(1) cost
        if (p_nIndex == (this.itemCount - 1))
            this.deleteLastItem();
        else if((p_nIndex >= 0) && (p_nIndex < this.itemCount))
        {
            // For any item runs a for loop with O(n) cost
            for(int i = p_nIndex; i < (this.itemCount - 1); i++)
                this.items[i] = this.items[i+1];            
            items[itemCount - 1] = null;
            itemCount--;
        }
    }
    //--------------------------------------------------------------------------
    // This method will help us display the data structure in the UI
    @Override
    public String toString()
    {
        String sResult = "";
        for(int i=0; i < this.itemCount; i++)
        {
            if(i>0)
            {
                sResult += "\r\n";
            }
            sResult += Integer.toString(i+1) + ":" + this.items[i];
        }
        return sResult;
    }
    //--------------------------------------------------------------------------
}

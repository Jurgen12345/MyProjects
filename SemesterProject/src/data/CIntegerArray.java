/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package data;

/**
 *
 * @author 20210421
 */
public class CIntegerArray {

    
    //--------------------------------------------------------------------------
    protected int itemCount = 0; // We make this field protected so it can be used by descendants.
    // ................................................
    public int getItemCount()  {
        return this.itemCount;
    }
    //--------------------------------------------------------------------------
    protected int[] items; // We make this field protected so it can be used by descendants.
    // ................................................
    public int getItem(int index) {
        return this.items[index];
    }
    // ................................................
    public void setItem(int index, int items) {
        this.items[index] = items;
    }
    //--------------------------------------------------------------------------
    
    
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
    public CIntegerArray(int p_nPageSize) 
    {
        
        
        this.pageSize = p_nPageSize;
        this.pages    = 1;
        this.capacity = pages * pageSize;

        this.items = new int[this.capacity];
        System.out.println("Created array with capacity to hold " + capacity + " items");
    }
    //--------------------------------------------------------------------------
    private void expand()
    {
        // Increase the pages (thus the capacity) and create a new array object
        this.pages ++;
        this.capacity = pages * pageSize;
        int[] newArray = new int[this.capacity];
        
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

        this.items = new int[this.capacity];
        System.out.println("Emptied array the new capacity can hold " + capacity + " items");
    }
    //--------------------------------------------------------------------------
    public void Append(int p_sItem)
    {
        if (itemCount >= capacity)
            expand();
            
        items[itemCount] = p_sItem;
        itemCount++;
        
    }
    //--------------------------------------------------------------------------
    public void moveItemsForInsert(int p_nInsertPosition)
    {
        for(int i = this.itemCount - 1; i >= p_nInsertPosition; i--)
            this.items[i+1] = this.items[i];

      //  items[p_nInsertPosition] = null;
    }    
    //--------------------------------------------------------------------------
    public void Insert(int p_nIndex, int p_sItem)
    {
        // If outside of the upper array bound
        if (p_nIndex >= this.itemCount)
            // Simple append to the end with O(1) cost
            this.Append(p_sItem);
        else
        {
            if (itemCount >= capacity)
                expand();            
            
            // Move items to insert at p_nIndex with O(n) cost
            this.moveItemsForInsert(p_nIndex);
            items[p_nIndex] = p_sItem;
            this.itemCount += 1;
        }
    }
    //--------------------------------------------------------------------------
    public void DeleteLastItem()
    {
      //  items[itemCount - 1] = null;
        itemCount--;
    }
    //--------------------------------------------------------------------------
    public void Delete(int p_nIndex)  
    {
        // For the last item runs a simple logic with O(1) cost
        if (p_nIndex == (this.itemCount - 1))
            this.DeleteLastItem();
        else if((p_nIndex >= 0) && (p_nIndex < this.itemCount))
        {
            // For any item runs a for loop with O(n) cost
            for(int i = p_nIndex; i < (this.itemCount - 1); i++)
                this.items[i] = this.items[i+1];            
          //  items[itemCount] = null;
            itemCount--;
        }
    }
    //--------------------------------------------------------------------------
    // Exhaustive search algorithm
    public int Search(int p_sSearchValue)
    {
        int nFoundIndex = -1;
        for(int i = 0; i < this.itemCount; i++)
        {
            if (this.items[i] == (p_sSearchValue))
            {
                nFoundIndex = i;
                break;
            }
        }
        return nFoundIndex;
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
            sResult += Integer.toString(i) + ":" + this.items[i];
        }
        return sResult;
    }
    //--------------------------------------------------------------------------
}

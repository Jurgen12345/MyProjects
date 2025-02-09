/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package data;

/**
 *
 * @author Operator
 */
public class CStringQueue extends CArray
{
    //--------------------------------------------------------------------------
    public CStringQueue(int p_nPageSize) 
    {
        super(p_nPageSize);
    }
    //--------------------------------------------------------------------------
    public void Enqueue(String p_sItem)
    {
        this.append(p_sItem);
    }
    //--------------------------------------------------------------------------
    public String Dequeue()  
    {
       int nFirstItemIndex =  0;
       String sItem = this.items[nFirstItemIndex];
       this.deleteFirstItem();
       return sItem;
    }      
    //--------------------------------------------------------------------------
    public String Peek(int p_nIndex)
    {
        int nFirstItemIndex =  0;
        return this.items[nFirstItemIndex];
    }
    //--------------------------------------------------------------------------  
    
    public String callsToString(){
        return this.toString();
    }
    
    public boolean isEmpty()
    {
      return this.itemCount == 0;
    }
}
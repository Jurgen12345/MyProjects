package data;

public class CStringStack extends CArray
{
    //--------------------------------------------------------------------------
    public CStringStack(int p_nPageSize) 
    {
        super(p_nPageSize);
    }
    //--------------------------------------------------------------------------
    public void Push(String p_sItem)
    {
        this.append(p_sItem);
    }
    //--------------------------------------------------------------------------
    public String Pop()  
    {
       String sItem = null;
       
       int nStackTopIndex =  this.itemCount - 1;
       if (nStackTopIndex >= 0)
       {
          sItem = this.items[nStackTopIndex];
          this.deleteLastItem();
       }
       return sItem;
    }      
    //--------------------------------------------------------------------------
    public String Peek(int p_nIndex)
    {
        int nStackTopIndex =  this.itemCount - 1;
        return this.items[nStackTopIndex];
    }
    //--------------------------------------------------------------------------
}

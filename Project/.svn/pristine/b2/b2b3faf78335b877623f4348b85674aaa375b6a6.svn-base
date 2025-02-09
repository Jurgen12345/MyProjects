using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    // [C#] This
    public class CTreeNodeList<T>: CArray<CTreeNode<T>>, IEnumerable<CTreeNode<T>>
    {
        #region // IEnumerable \\
        //--------------------------------------------------------------------------
        public IEnumerator<CTreeNode<T>> GetEnumerator()
        {
            for(int i = 0; i< this.ItemCount; i++)
                yield return this.items[i];
        }
        //--------------------------------------------------------------------------
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //--------------------------------------------------------------------------
        #endregion


        //--------------------------------------------------------------------------
        public new void Append(CTreeNode<T> p_oNode)
        {
            this.appendItem(p_oNode);
        }
        //--------------------------------------------------------------------------
        public void AppendNode(CTreeNode<T> p_oNode)
        {
            this.appendItem(p_oNode);
        }
        //--------------------------------------------------------------------------
        public void RemoveNode(CTreeNode<T> p_oNode)
        {
            this.remove(p_oNode);
        }
        //--------------------------------------------------------------------------
        public override String ToString()
        {
            String sResult = String.Empty;
            foreach(CTreeNode<T> p_oNode in this)
            {
                if (sResult != String.Empty)
                    sResult += "\r\n";

                sResult += $"[{p_oNode.Value}]".PadRight(16) + $" {p_oNode.Path}";
            }
            return sResult;
        }
        //--------------------------------------------------------------------------
    }
}

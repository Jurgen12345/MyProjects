using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    public class CTreeNode<T>: IComparable<CTreeNode<T>>
    {
        #region (( Fields for the implementation of a tree node ))
        protected CTreeNode<T>?     parent = null;         // The parent node of this tree node
        // ................................................................
        protected CTreeNodeList<T>  children = new CTreeNodeList<T>();  // All child nodes of this tree node
        public CTreeNodeList<T> Children { get { return children; } }
        // ................................................................
        public T? Value { get; set; } = default(T);                  // Some value/item that the tree node may store.
        public String Name { get; set; } = String.Empty;             // The name of the tree node
        #endregion

        #region (( Properties of a tree node ))
        // ................................................................
        public String Path
        {
            get
            { 
                if (this.parent == null)
                    return "/";
                else if (this.parent.IsRoot)
                    return parent.Path + Name; // [RECURSION]
                else
                    return parent.Path + "/" + Name ; // [RECURSION]
            } 
        }
        // ................................................................
        public int Level
        {   
            get 
            { 
                if (this.parent == null)
                    return 0;
                else
                    return parent.Level + 1; // [RECURSION]
            } 
        }
        // ................................................................
        public CTreeNode<T> Root
        {   
            get
            { 
                if (this.parent == null)
                    return this; // If there is no parent this is a root some (sub)tree
                else
                    return this.parent.Root;  // [RECURSION]
            }
        }
        // ................................................................
        public bool IsRoot { get { return this.parent == null; } }
        // ................................................................
        // Indexer property that returns a child by index
        public CTreeNode<T>? this[int index] 
        { 
            get
            {
                return this.children[index];
            }
        }
        // ................................................................
        public int ChildCount { get { return this.children.ItemCount; } }
        // ................................................................
        public bool IsLeaf { get { return this.children.ItemCount == 0;} }
        // ................................................................
        public CTreeNode<T> Parent 
        {   
            get { return this.parent; } 
            set
            {
                // This code allows a node to switch its parent

                // Removes this node from the children of its current parent.
                if (this.parent != null)
                    this.parent.children.RemoveNode(this);

                // Parent node of this node object is set/replaced.
                this.parent = value;

                // Adds this node to the children of the new parent.
                if (this.parent != null)
                    this.parent.children.AppendNode(this);
            }
        }
        // ................................................................
        #endregion



        //--------------------------------------------------------------------------    
        // Creates a TreeNode that is not added to a tree
        public CTreeNode()
        {
        }
        //--------------------------------------------------------------------------        
        // Creates a TreeNode and adds it under a given parent node.
        public CTreeNode(CTreeNode<T> p_oParent)
        {
            this.Parent = p_oParent;
        }
        //--------------------------------------------------------------------------
        public int CompareTo(CTreeNode<T>? other)
        {
            if (this == other)
                return 0;
            else
                return this.Name.CompareTo(other.Name);
        }

        //--------------------------------------------------------------------------            
        public CTreeNode<T> NewChild(Guid p_oGuid) // [POLYMORPHISM] Overloaded
        {
            return NewChild(p_oGuid.ToString());
        }
        //--------------------------------------------------------------------------            
        public CTreeNode<T> NewChild(int p_nNodeId) // [POLYMORPHISM] Overloaded
        {
            return NewChild(p_nNodeId.ToString());
        }
        //--------------------------------------------------------------------------            
        public CTreeNode<T> NewChild(String p_sNodeName) // [POLYMORPHISM] Overloaded
        {
            CTreeNode<T> oNewChildNode = new CTreeNode<T>();
            oNewChildNode.Name = p_sNodeName;
            oNewChildNode.Parent = this;
            return oNewChildNode;
        }
        //--------------------------------------------------------------------------            
        public int AddChild(CTreeNode<T> p_oChildNode)
        {
            // This node object becomes the parent of p_oChildNoe
            p_oChildNode.Parent = this;
            return (this.children.ItemCount - 1);
        }
        //--------------------------------------------------------------------------            
        public void RemoveChild(CTreeNode<T> p_oChildNode)  
        {
            // Setting null will activate the code in the setter that 
            // removes p_oChildNode from the children of this node object.
            p_oChildNode.Parent = null;
        }
        //--------------------------------------------------------------------------            
        public void RemoveChild(String p_sName)
        {   
            // Searching for a node by its name, goign through all children.
            foreach(CTreeNode<T> oChildNode in this.children)
            {
                if (oChildNode.Name == p_sName)
                {   // We disconnect this node from its parent that leads to removal.
                    oChildNode.Parent = null;
                    break;
                }
            }
        }
        //--------------------------------------------------------------------------
        // Postorder DFS traversal that deletes the node and all the nodes beneath it
        public void Delete()
        {
            // Depth First: We recurse on each one of the children. This will go to 
            // up to the maximum depth before moving to the next child.
            foreach (CTreeNode<T> oChildNode in this.children)
                oChildNode.Delete();

            // Preorder: Removing this node from its parent
            Debug.WriteLine(new String(' ', this.Level * 2) + $"Removing L{this.Level} node {this.Name}");
            if (this.parent != null)
                this.parent.RemoveChild(this);
            
        }
        //--------------------------------------------------------------------------            
        public override string ToString()
        {
            return this.Path;
        }
        //--------------------------------------------------------------------------

    }

}

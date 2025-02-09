using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    public class CTree<T>
    {
        public CTreeNode<T> Root;

        private CTreeNodeList<T>? nodeList = null; // Needed for traversal operations
        
        //--------------------------------------------------------------------------
        public CTree()
        {
           this.Root = new CTreeNode<T>();
        }
        //--------------------------------------------------------------------------
        public CTree(CTreeNode<T> p_oRoot)
        {
            this.Root = p_oRoot;
        }
        //--------------------------------------------------------------------------
        public void Clear()
        {
            this.Root.Delete();
            this.Root = new CTreeNode<T>();
        }
        //--------------------------------------------------------------------------
        // Preorder DFS traversal that adds the node to the list of nodes
        protected void recursePreorderAppendToNodeList(CTreeNode<T> p_oCurrentNode, int p_nDepth)
        {
            // Preorder = We process the current node before its children
            nodeList.AppendNode(p_oCurrentNode);
            debugNodeAccess(nodeList.ItemCount, p_oCurrentNode, p_nDepth);

            // Depth First: We recurse on each one of the children. This will go to 
            // up to the maximum depth before moving to the next child.
            foreach (CTreeNode<T> oChildNode in p_oCurrentNode.Children)
                recursePreorderAppendToNodeList(oChildNode, p_nDepth + 1);
        }
        //--------------------------------------------------------------------------
        // Postorder DFS traversal that adds the node to the list of nodes
        protected void recursePostorderAppendToNodeList(CTreeNode<T> p_oCurrentNode, int p_nDepth)
        {
            // Depth First: We recurse on each one of the children. This will go to 
            // up to the maximum depth before moving to the next child.
            foreach (CTreeNode<T> oChildNode in p_oCurrentNode.Children)
                recursePostorderAppendToNodeList(oChildNode, p_nDepth + 1);

            // Postorder = We process the current node after returning from recursion on children
            nodeList.AppendNode(p_oCurrentNode);
            debugNodeAccess(nodeList.ItemCount, p_oCurrentNode, p_nDepth);
        }
        //--------------------------------------------------------------------------
        // DFT is implemented here with recursion
        public CTreeNodeList<T> TraverseDepthFirst(bool p_bIsPreorder)
        {
            nodeList = new CTreeNodeList<T>();
            if (p_bIsPreorder)
            {
                Debug.WriteLine("------ Pre-Order Depth-First Traversal ------");
                recursePreorderAppendToNodeList(Root, 0);
            }
            else
            {
                Debug.WriteLine("------ Post-Order Depth-First Traversal ------");
                recursePostorderAppendToNodeList(Root, 0);
            }
            return nodeList;
        }
        //--------------------------------------------------------------------------
        // BFT is implemented here with an auxiliary queue data structure
        public CTreeNodeList<T> TraverseBreadthFirst()
        {
            Debug.WriteLine("------ Breadth-First Traversal ------");
            CTreeNodeList<T> oNodeList = new CTreeNodeList<T>();
            CTreeNodeQueue<T> oQueue = new CTreeNodeQueue<T>();
            oQueue.Enqueue(this.Root);

            while (!oQueue.IsEmpty)
            {
                // Breadth First: We use a queue and there is no recursion.
                CTreeNode<T>? oNode = oQueue.Dequeue();
                if (oNode != null)
                { 
                    oNodeList.AppendNode(oNode);
                    debugNodeAccess(oNodeList.ItemCount, oNode, -1);

                    // Breadth First: We enqueue children nodes (if any).
                    foreach (CTreeNode<T> oChildNode in oNode.Children)
                        oQueue.Enqueue(oChildNode);
                }
            }

            return oNodeList;
        }
        //--------------------------------------------------------------------------
        protected CTreeNode<T>? recurseFollowPath(CQueue<String> p_oPathNodeNames, CTreeNode<T> p_oCurrentNode, int p_nDepth)
        {
            CTreeNode<T>? oResult = null;
            // We will try to visit the next node in the queue
            string? sNodeName = p_oPathNodeNames.Dequeue();

            // (Exhaustive) Search the children with the name of the next node
            foreach(CTreeNode<T> oNode in p_oCurrentNode.Children)
            {
                Debug.Write($"D{p_nDepth}{getIndentation(p_nDepth)} ({oNode.Name} == {sNodeName})");

                if (oNode.Name == sNodeName)
                {
                    Debug.WriteLine(" -> true");
                    // If this is the last node in the queue, then it is our destination.
                    // At this point we do not recurse any more, and we return this node as the result.
                    if (p_oPathNodeNames.IsEmpty)
                        oResult = oNode;
                    else
                        // There are still nodes in the path, recurse on the current node.
                        oResult = recurseFollowPath(p_oPathNodeNames, oNode, p_nDepth + 1);
                    break;
                }
                else
                    Debug.WriteLine("");
            };

            return oResult;
        }
        //--------------------------------------------------------------------------
        public CTreeNode<T>? Follow(string p_sPath)
        {
            Debug.WriteLine("------ Following Path ------");
            // We split the path to an array of node names that is separated with '/'
            string[] sNodeNames = p_sPath.Split("/");

            // Visiting a list of locations is a FIFO scheme. Hence we need a queue
            // where we enqueue node names
            CQueue<string> oPathNodeNames = new CQueue<string>(32);
            foreach(string sNodeName in sNodeNames)
                oPathNodeNames.Enqueue(sNodeName);

            // In an empty tree the result will be the root node
            CTreeNode<T>? oResult = this.Root;
            if (!oPathNodeNames.IsEmpty)
            {
                oPathNodeNames.Dequeue(); // Remove the nodename "" that stands for the root node
                oResult = recurseFollowPath(oPathNodeNames, Root, 1); // Start recursion from the root
            }
            return oResult;
        }
        //--------------------------------------------------------------------------
        private void debugNodeAccess(int p_nOrder, CTreeNode<T> p_oNode, int p_nRecursionDepth)
        {
            if (p_nRecursionDepth >= 0)
                Debug.WriteLine(string.Format(" {0,3}: D{1} {2}{3}",
                                        p_nOrder,
                                        p_nRecursionDepth,
                                        getIndentation(p_nRecursionDepth),
                                        p_oNode.Name));
            else
                Debug.WriteLine(string.Format(" {0,3} {1}", 
                                        p_nOrder,
                                        p_oNode.ToString())
                                   );
        }
        //--------------------------------------------------------------------------    
        // Returns an identation with space characters according to a given depth
        protected string getIndentation(int p_nDepth)
        {
            string sIdentation = "";
            if (p_nDepth - 1 >= 0)
                sIdentation = new string(' ', (p_nDepth - 1) * 4);

            return sIdentation;
        }
        //--------------------------------------------------------------------------
        // Preorder DFS traversal that adds the node representation to a string
        protected string recurseNodeDescription(CTreeNode<T> p_oCurrentNode, int p_nDepth)
        {
            string sResult = ">";
            if (!p_oCurrentNode.IsRoot)
                sResult = getIndentation(p_nDepth) + "|__ ";

            // Preorder: We get the name before any recursion on the list of children 
            sResult += p_oCurrentNode.Name;

            // Depth First: We recurse on each one of the children. This will go to 
            // up to the maximum depth before moving to the next child.
            foreach(CTreeNode<T> oChildNode in p_oCurrentNode.Children)
                sResult += "\r\n" + recurseNodeDescription(oChildNode, p_nDepth + 1);

            return sResult;
        }
        //--------------------------------------------------------------------------            
        public override string ToString()
        {
            // Depth First Traversal: Starts recursion from the root
            return recurseNodeDescription(Root, 0);
        }
        //--------------------------------------------------------------------------
    }

}

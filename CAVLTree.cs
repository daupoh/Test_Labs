using System;
using System.Collections.Generic;

namespace wf_testLabs
{
    class CAvlTree
    {        
        public CAvlNode Root { get; private set; }
        public int Height
        {
            get
            {
                return Root.Height;
            }
        }
        public int HeightDifference
        {
            get
            {
                return Root.HeightDifference;
            }
        }
        public int LeftTreeHeight 
        {
            get
            {
                return Root.LeftSon.Height;
            } 
        }
        public int RightTreeHeight
        {
            get
            {
                return Root.RightSon.Height;
            }
        }
        public CAvlTree ()
        {
            Root = null;
        }
        public void Destroy()
        {
            if (Root == null)
            {
                Root.Dispose();
                Root = null;
            }
        }
        public int[] ToArray()
        {
            int[] aTree = null;
            if (Root != null)
            {
                aTree = Root.ToArray(new List<int>(),Root).ToArray();
            }            
            return aTree;
        }
        public void AddNode(int iNodeKey) 
        {
            if (Root == null)
            {
                Root = new CAvlNode(iNodeKey);
            }
            else
            {
                Root = Root.AddNode(iNodeKey, Root);
            }
        }
        public void DeleteNode(int iNodeKey)
        {            
            if (Root != null)
            {
                Root = Root.DeleteNode(iNodeKey,Root);
            }            
        }
        public CAvlNode FindNode (int iNodeKey) 
        {
            CAvlNode rNode;
            if (Root == null)
            {
                rNode = null;
            }
            else
            {
                rNode = Root.FindNode(iNodeKey);
            }
            return rNode;
        }
      

    }
}

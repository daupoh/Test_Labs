using System;
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
        public void AddNode(int iNodeKey) 
        {
            if (Root == null)
            {
                Root = new CAvlNode(iNodeKey);
            }
            else
            {
                Root.AddNode(iNodeKey);
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

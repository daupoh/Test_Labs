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

        }
        public void AddNode(int fNodeKey) 
        {
            if (Root == null)
            {
                Root = new CAvlNode(fNodeKey);
            }
            else
            {
                Root.AddNode(fNodeKey);
            }
        }
        public CAvlNode FindNode (int fNodeKey) 
        {
            CAvlNode rFindedNode = null; 
            
            return rFindedNode; 
        }
        public void DeleteNode(int fNodeKey)
        {

        }

    }
}

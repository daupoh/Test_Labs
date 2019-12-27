
namespace wf_testLabs
{
    class CAvlNode
    {   
        public int Key { get; }
        public CAvlNode LeftSon { get; private set; }
        public CAvlNode RightSon { get; private set; }
        public int Height
        {
            get
            {
                int iHeight = 1;
                if (LeftSon!=null)
                {
                    iHeight += LeftSon.Height;
                }
                if (RightSon!= null)
                {
                    iHeight += RightSon.Height;
                }
                return iHeight;
            }
        }

        public CAvlNode(int iKey)
        {
            Key = iKey;
            LeftSon = null;
            RightSon = null;
        }

    }
}

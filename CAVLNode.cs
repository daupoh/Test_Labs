
namespace wf_testLabs
{
    class CAvlNode
    {   
        public int Key { get; }
        public CAvlNode LeftSon { get; private set; }
        public CAvlNode RightSon { get; private set; }

        public CAvlNode(int iKey)
        {
            Key = iKey;
            LeftSon = null;
            RightSon = null;
        }

    }
}

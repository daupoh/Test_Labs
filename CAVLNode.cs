using System;
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
                int iHeight = 1, iLeftHeight=0, iRightHeight=0;
                if (LeftSon!=null)
                {
                    iLeftHeight += LeftSon.Height;
                }
                if (RightSon!= null)
                {
                    iRightHeight += RightSon.Height;
                }
                iHeight += Math.Max(iLeftHeight, iRightHeight);
                return iHeight;
            }
        }
        public int HeightDifference
        {
            get
            {
                int iHeightRight = 0, iHeightLeft = 0;
                if (RightSon != null)
                {
                    iHeightRight = RightSon.Height;
                }
                if (LeftSon != null)
                {
                    iHeightLeft = LeftSon.Height;
                }
                return iHeightRight - iHeightLeft;
            }
        }
        public CAvlNode(int iKey)
        {
            Key = iKey;
            LeftSon = null;
            RightSon = null;
        }
        public void AddNode(int fNodeKey)
        {
            if (fNodeKey>Key)
            {
                if (RightSon!=null)
                {
                    RightSon.AddNode(fNodeKey);
                }
                else
                {
                    RightSon = new CAvlNode(fNodeKey);
                }
            } 
            else
            {
                if (LeftSon != null)
                {
                    LeftSon.AddNode(fNodeKey);
                }
                else
                {
                    LeftSon = new CAvlNode(fNodeKey);
                }
            }
            Balance();
        }
       
        private void Balance()
        {
            int iHeightDifference = HeightDifference;
            if (iHeightDifference==2)
            {
                if (RightSon!=null && RightSon.HeightDifference<0)
                {
                    RightSon.RightTurn();
                }
                LeftTurn();
            }
            else if (iHeightDifference==-2)
            {
                if (LeftSon!=null && LeftSon.HeightDifference>0)
                {
                    LeftSon.LeftTurn();
                }
                RightTurn();
            } 
        }
        private void RightTurn()
        {
            CAvlNode rNode = LeftSon;
            LeftSon = rNode.RightSon;
            rNode.RightSon = this;
        }
        private void LeftTurn()
        {
            CAvlNode rNode = RightSon;
            RightSon = rNode.LeftSon;
            rNode.LeftSon = this;
        }

    }
}

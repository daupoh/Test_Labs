using System;
namespace wf_testLabs
{
    class CAvlNode: IDisposable
    {   
        public int Key { get; private set; }
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
        
        public void AddNode(int iNodeKey)
        {
            if (iNodeKey>Key)
            {
                if (RightSon!=null)
                {
                    RightSon.AddNode(iNodeKey);
                }
                else
                {
                    RightSon = new CAvlNode(iNodeKey);
                }
            } 
            else
            {
                if (LeftSon != null)
                {
                    LeftSon.AddNode(iNodeKey);
                }
                else
                {
                    LeftSon = new CAvlNode(iNodeKey);
                }
            }
            Balance();
        }
        public CAvlNode FindNode(int iNodeKey)
        {
            CAvlNode rNode=null;
            if (iNodeKey==Key)
            {
                rNode = this;
            }
            else if (iNodeKey > Key)
            {
                if (RightSon != null)
                {
                    rNode = RightSon.FindNode(iNodeKey);
                }              
            }
            else
            {
                if (LeftSon != null)
                {
                    rNode = LeftSon.FindNode(iNodeKey);
                }
               
            }            
            return rNode;
        }
        public void Dispose()
        {
            if (LeftSon != null)
            {
                LeftSon.Dispose();
            }
            if (RightSon != null)
            {
                RightSon.Dispose();
            }
            LeftSon = null;
            RightSon = null;
        }
       
        private void Balance()
        {
            int iHeightDifference = HeightDifference;
            if (iHeightDifference == 2)
            {
                if (RightSon != null && RightSon.HeightDifference < 0)
                {
                    RightSon.RightTurn();
                }
                LeftTurn();
            }
            else if (iHeightDifference == -2)
            {
                if (LeftSon != null && LeftSon.HeightDifference > 0)
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

using System;
using System.Collections.Generic;

namespace wf_testLabs
{
    class CAvlNode
    {
        public int Key { get; private set; }
        public int Height { get; private set; }
        public CAvlNode LeftSon { get; private set; }
        public CAvlNode RightSon { get; private set; }

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
            Height = 1;

        }
        public CAvlNode DeleteNode(int iNodeKey, CAvlNode rRoot)
        {
            CAvlNode rNode = null;
            if (rRoot != null)
            {
                if (iNodeKey < rRoot.Key)
                {
                    rRoot.LeftSon = DeleteNode(iNodeKey, rRoot.LeftSon);
                    rNode = Balance(rRoot);
                }
                else if (iNodeKey > rRoot.Key)
                {
                    rRoot.RightSon = DeleteNode(iNodeKey, rRoot.RightSon);
                    rNode = Balance(rRoot);
                }
                else
                {
                    CAvlNode rLeft = rRoot.LeftSon,
                        rRight = rRoot.RightSon;
                    rRoot = null;
                    if (rRight == null)
                    {
                        rNode = rLeft;
                    }
                    else
                    {
                        CAvlNode rMin = FindMin(rRight);
                        rMin.RightSon = DeleteMin(rRight);
                        rMin.LeftSon = rLeft;
                        Balance(rMin);
                        rNode = rMin;
                    }
                }                
            }
            return rNode;
        }
        public CAvlNode AddNode(int iNodeKey, CAvlNode rRoot)
        {
            CAvlNode rNode = null;
            if (rRoot==null)
            {
                rNode = new CAvlNode(iNodeKey);
                
            }
            else if (iNodeKey > rRoot.Key)
            {
                rRoot.RightSon = AddNode(iNodeKey,rRoot.RightSon);
                rNode = Balance(rRoot);
            }
            else
            {
                rRoot.LeftSon = AddNode(iNodeKey, rRoot.LeftSon);
                rNode = Balance(rRoot);
            }            
            return rNode;
        }
        public CAvlNode FindNode(int iNodeKey)
        {
            CAvlNode rNode = null;
            if (iNodeKey == Key)
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
        public List<int> ToArray(List<int> aNodes, CAvlNode rRoot)
        {
            if (rRoot.LeftSon != null)
            {
                aNodes = ToArray(aNodes, rRoot.LeftSon);
            }
            aNodes.Add(rRoot.Key);
            if (rRoot.RightSon != null)
            {
                aNodes = ToArray(aNodes, rRoot.RightSon);
            }
            return aNodes;
        }
        private CAvlNode FindMin(CAvlNode rRoot)
        {
            CAvlNode rMin;
            if (rRoot.LeftSon != null)
            {
                rMin = FindMin(rRoot.LeftSon);
            }
            else
            {
                rMin = rRoot;
            }
            return rMin;
        }
        private CAvlNode DeleteMin(CAvlNode rRoot)
        {
            CAvlNode rNode;
            if (rRoot.LeftSon == null)
            {
                rNode = rRoot.RightSon;
            }
            else
            {
                rRoot.LeftSon = DeleteMin(rRoot.LeftSon);
                Balance(rRoot);
                rNode = rRoot;
            }
            return rNode;
        }
        private CAvlNode Balance(CAvlNode rRoot)
        {            
            UpdateHeight(rRoot);
            int iHeightDifference = rRoot.HeightDifference;
            if (iHeightDifference == 2)
            {
                if (rRoot.RightSon != null && rRoot.RightSon.HeightDifference < 0)
                {
                    rRoot.RightSon= RightTurn(rRoot.RightSon);
                }
                rRoot=LeftTurn(rRoot);
            }
            else if (iHeightDifference == -2)
            {
                if (rRoot.LeftSon != null && rRoot.LeftSon.HeightDifference > 0)
                {
                    rRoot.LeftSon =LeftTurn(rRoot.LeftSon);
                }
                rRoot= RightTurn(rRoot);
            }
            return rRoot;
        }
        private CAvlNode RightTurn(CAvlNode rRoot)
        {
            CAvlNode rNode = rRoot.LeftSon;
            rRoot.LeftSon = rNode.RightSon;
            rNode.RightSon = rRoot;
            UpdateHeight(rRoot);
            UpdateHeight(rNode);
            return rNode;
        }
        private CAvlNode LeftTurn(CAvlNode rRoot)
        {
            CAvlNode rNode = rRoot.RightSon;
            rRoot.RightSon = rNode.LeftSon;
            rNode.LeftSon = rRoot;
            UpdateHeight(rRoot);
            UpdateHeight(rNode);
            return rNode;
        }
        private void UpdateHeight(CAvlNode rRoot)
        {
            if (rRoot != null)
            {
                int iHeightLeft = 0, iHeightRight = 0;
                if (rRoot.LeftSon != null)
                {
                    iHeightLeft = rRoot.LeftSon.Height;
                }
                if (rRoot.RightSon != null)
                {
                    iHeightRight = rRoot.RightSon.Height;
                }
                rRoot.Height = Math.Max(iHeightRight, iHeightLeft) + 1;
            }
        }
    }
}

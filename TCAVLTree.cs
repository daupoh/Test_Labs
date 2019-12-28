using NUnit.Framework;
using System;

namespace wf_testLabs
{
    [TestFixture]
    class TCAvlTree
    {
        CAvlTree rTree;
        [SetUp]
        public void SetUp()
        {
            rTree = new CAvlTree();
        }
        [TearDown]
        public void CleanUp()
        {
            rTree = null;
        }

        [Test]
        public void TestCreateAVLTree()
        {   
            Assert.IsNull(rTree.Root);
        }
        [Test]
        public void TestAddNode()
        {
            AddNodesToTree();
            Assert.IsTrue(rTree.Root.Key.Equals(5),"Корень дерева должен быть равен {0}",5);
            Assert.IsTrue(rTree.Root.LeftSon.Key.Equals(3), "Левое поддерево должно иметь ключ равный {0}", 3);
            Assert.IsTrue(rTree.Root.RightSon.Key.Equals(6), "Правое поддерево должно иметь ключ равный {0}", 6);
            CheckHeightDifference(rTree.Root);
        }
        [Test]
        public void TestFindNode()
        {
            AddNodesToTree();
            CAvlNode rNode = rTree.FindNode(3);
            Assert.IsTrue(rNode.Key.Equals(3), "Найденный элемент должен иметь ключ {0}", 3);           
            rNode = rTree.FindNode(10);
            Assert.IsNull(rNode);
        }
        [Test]
        public void TestHeightTree()
        {
            AddNodesToTree();
            Assert.IsTrue(rTree.Root.Height.Equals(4), "Высота дерева должна быть равна {0}, а равна {1}",4, rTree.Root.Height);
            Assert.IsTrue(rTree.Root.LeftSon.Height.Equals(3), "Высота левого поддерева должна быть равна {0}", 3);
            Assert.IsTrue(rTree.Root.RightSon.Height.Equals(2), "Высота правого поддерева должна быть равна {0}", 2);
        }
       
        private void AddNodesToTree()
        {
            rTree.AddNode(5);
            rTree.AddNode(3);
            rTree.AddNode(6);
            rTree.AddNode(4);
            rTree.AddNode(7);
            rTree.AddNode(2);
            rTree.AddNode(1);
            rTree.AddNode(0);
            rTree.AddNode(-1);
        }
        private void CheckHeightDifference(CAvlNode rNode)
        {
            Assert.IsTrue(Math.Abs(rNode.HeightDifference) < 2, "Разница высот в дереве на узле с ключом {0}" +
                " не должна превышать 1, а равна {1}", rNode.Key, Math.Abs(rNode.HeightDifference));
            if (rNode.LeftSon!=null)
            {
                CheckHeightDifference(rNode.LeftSon);
            }
            if (rNode.RightSon!=null)
            {
                CheckHeightDifference(rNode.RightSon);
            }
        }

    }
}

using NUnit.Framework;
using System;

namespace wf_testLabs
{
    [TestFixture]
    class TCAvlTree
    {
        CAvlTree m_rTree;
        [SetUp]
        public void SetUp()
        {
            m_rTree = new CAvlTree();
        }
        [TearDown]
        public void CleanUp()
        {
            m_rTree = null;
        }

        [Test]
        public void TestCreateAVLTree()
        {   
            Assert.IsNull(m_rTree.Root);
        }
        [Test]
        public void TestAddNode()
        {
            AddNodesToTree();
            Assert.IsTrue(m_rTree.Root.Key.Equals(5),"Корень дерева должен быть равен {0}",5);
            Assert.IsTrue(m_rTree.Root.LeftSon.Key.Equals(1), "Левое поддерево должно иметь ключ равный {0}", 1);
            Assert.IsTrue(m_rTree.Root.RightSon.Key.Equals(6), "Правое поддерево должно иметь ключ равный {0}", 6);
            Assert.IsTrue(Math.Abs(m_rTree.HeightDifference) < 2,"Разница высот поддеревьев должна быть меньше 2");
            Assert.IsTrue(m_rTree.ToArray().Length==9, "Количество нод в дереве должно быть равно {0}",9);
            CheckHeightDifference(m_rTree.Root);
        }

        [Test]
        public void TestDeleteNode()
        {
            AddNodesToTree();
            m_rTree.DeleteNode(6);
            m_rTree.DeleteNode(5);
            Assert.IsNull(m_rTree.FindNode(5),"Нода с ключом {0} должна быть удалена.",5);
            Assert.IsNull(m_rTree.FindNode(6), "Нода с ключом {0} должна быть удалена.", 6);
            Assert.IsNotNull(m_rTree.FindNode(3), "Нода с ключом {0} должна быть найдена.", 3);
            Assert.IsNotNull(m_rTree.FindNode(4), "Нода с ключом {0} должна быть найдена.", 4);
            Assert.IsTrue(Math.Abs(m_rTree.HeightDifference) < 2,"Разница высот деревьев не должна превышать 1.");
        }
                
        [Test]
        public void TestFindNode()
        {
            AddNodesToTree();
            CAvlNode rNode = m_rTree.FindNode(3);
            Assert.IsTrue(rNode.Key.Equals(3), "Найденный элемент должен иметь ключ {0}", 3);           
            rNode = m_rTree.FindNode(10);
            Assert.IsNull(rNode);
        }
        [Test]
        public void TestHeightTree()
        {
            AddNodesToTree();
            Assert.IsTrue(m_rTree.Root.Height.Equals(4), "Высота дерева должна быть равна {0}, а равна {1}",4, m_rTree.Root.Height);
            Assert.IsTrue(m_rTree.Root.LeftSon.Height.Equals(3), "Высота левого поддерева должна быть равна {0}", 3);
            Assert.IsTrue(m_rTree.Root.RightSon.Height.Equals(2), "Высота правого поддерева должна быть равна {0}", 2);
        }
       
        private void AddNodesToTree()
        {
            m_rTree.AddNode(5);
            m_rTree.AddNode(3);
            m_rTree.AddNode(6);
            m_rTree.AddNode(4);
            m_rTree.AddNode(7);
            m_rTree.AddNode(2);
            m_rTree.AddNode(1);
            m_rTree.AddNode(0);
            m_rTree.AddNode(-1);
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

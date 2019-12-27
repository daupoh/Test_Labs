using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs
{
    [TestFixture]
    class TCAVLTree
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
            rTree.AddNode(5);
            rTree.AddNode(3);
            rTree.AddNode(6);
            Assert.IsTrue(rTree.Root.Key.Equals(5),"Корень дерева должен быть равен {0}",5);
            Assert.IsTrue(rTree.Root.Key.Equals(3), "Левое поддерево должно иметь ключ равный {0}", 3);
            Assert.IsTrue(rTree.Root.Key.Equals(6), "Правое поддерево должно иметь ключ равный {0}", 6);

        }
        [Test]
        public void TestFindNode()
        {
            rTree.AddNode(5);
            rTree.AddNode(3);
            rTree.AddNode(6);
            rTree.AddNode(4);
            rTree.AddNode(7);
            rTree.AddNode(2);
            CAvlNode rNode = rTree.FindNode(3);
            Assert.IsTrue(rNode.Key.Equals(3), "Найденный элемент должен иметь ключ {0}", 3);
            Assert.IsTrue(rNode.LeftSon.Key.Equals(2), "Левый сын найденного элемента должен иметь ключ {0}", 2);
            Assert.IsTrue(rNode.RightSon.Key.Equals(3), "Правый сын найденного элемента должен иметь ключ {0}", 4);
        }

    }
}

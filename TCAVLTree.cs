using NUnit.Framework;


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
            Assert.IsTrue(rTree.Root.Key.Equals(3), "Левое поддерево должно иметь ключ равный {0}", 3);
            Assert.IsTrue(rTree.Root.Key.Equals(6), "Правое поддерево должно иметь ключ равный {0}", 6);

        }
        [Test]
        public void TestFindNode()
        {
            AddNodesToTree();
            CAvlNode rNode = rTree.FindNode(3);
            Assert.IsTrue(rNode.Key.Equals(3), "Найденный элемент должен иметь ключ {0}", 3);
            Assert.IsTrue(rNode.LeftSon.Key.Equals(2), "Левый сын найденного элемента должен иметь ключ {0}", 2);
            Assert.IsTrue(rNode.RightSon.Key.Equals(3), "Правый сын найденного элемента должен иметь ключ {0}", 4);
        }
        [Test]
        public void TestHeightTree()
        {
            AddNodesToTree();
            Assert.IsTrue(rTree.Root.Height.Equals(6),"Высота дерева")
        }
        [Test]
        public void TestDeleteNode()
        {

        }
        private void AddNodesToTree()
        {
            rTree.AddNode(5);
            rTree.AddNode(3);
            rTree.AddNode(6);
            rTree.AddNode(4);
            rTree.AddNode(7);
            rTree.AddNode(2);
        }

    }
}

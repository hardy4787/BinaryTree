using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Tests
{
    [TestClass()]
    public class BinaryTreeTests
    {
        private static BinaryTree<int> TestTree;
        [TestInitialize]
        public void TestInitialize()
        {
            TestTree = new BinaryTree<int>(1) { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }


        [TestMethod]
        public void BinaryTree_CreateTreeWithNullHead_ExceptionReturned()
        {
            try
            {
                BinaryTree<string> tree = new BinaryTree<string>(null);
            }
            catch (Exception ex)
            {
                StringAssert.Equals(ex.Message, "The value must be comparable or a comparator must be passed.");
                return;
            }
            Assert.Fail("Exception was not thrown");
        }


        [TestMethod]
        public void Add_AddValueTwentyToTestTree_TreeContainsTwenty()
        {
            TestTree.Add(20);
            bool expected = true;

            bool actual = TestTree.Contains(20);
            Assert.AreEqual(expected, actual, "Tree dont have added value");


        }

        [TestMethod]
        public void Contains_DoesTestTreeValueOne_TreeContainsOne()
        {
            Assert.IsTrue(TestTree.Contains(1));
        }

        [TestMethod]
        public void Contains_SearchingElementWithNullValue_ReturnedFalse()
        {
            BinaryTree<string> tree = new BinaryTree<string>(" ");
            string s1 = null;
            Assert.IsFalse(tree.Contains(s1));
        }


        [TestMethod]
        public void GetEnumerator_GetAllElementFromTestTreeAndPutTheirInTestCollection_TreeAndCollectionHaveSameElements()
        {
            ICollection<int> TestCollection = new List<int>();
            foreach (var el in TestTree)
                TestCollection.Add(el);
            int expectedCount = 0;
            int actualCount = -1;

            if (TestTree.Count == TestCollection.Count)
            {
                var Result = TestCollection.Except(TestTree);
                actualCount = Result.Count();
            }

            Assert.AreEqual(expectedCount, actualCount);
        }

    }
}
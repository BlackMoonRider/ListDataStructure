using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListDataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDataStructure.Tests
{
    [TestClass()]
    public class DynamicArrayTests
    {
        private DynamicArray CreateTestArray()
        {
            DynamicArray dynamicArray = new DynamicArray();

            dynamicArray.Add("a");
            dynamicArray.Add(14);
            dynamicArray.Add('3');

            return dynamicArray;
        }

        [TestMethod()]
        public void AddTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            Assert.IsTrue((string)dynamicArray[0] == "a");
            Assert.IsTrue((int)dynamicArray[1] == 14);
            Assert.IsTrue((char)dynamicArray[2] == '3');
        }

        [TestMethod()]
        public void InsertAtNextTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            dynamicArray.Insert(3, "bam");

            Assert.IsTrue((string)dynamicArray[3] == "bam");
        }

        [TestMethod()]
        public void InsertAtZeroTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            dynamicArray.Insert(0, "bam");

            Assert.IsTrue((string)dynamicArray[0] == "bam");
            Assert.IsTrue((string)dynamicArray[1] == "a");
            Assert.IsTrue((int)dynamicArray[2] == 14);
            Assert.IsTrue((char)dynamicArray[3] == '3');
        }

        [TestMethod()]
        public void InsertBeyondArrayTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            dynamicArray.Insert(10, "bam");


            Assert.IsTrue((string)dynamicArray[0] == "a");
            Assert.IsTrue((int)dynamicArray[1] == 14);
            Assert.IsTrue((char)dynamicArray[2] == '3');
            Assert.IsTrue((string)dynamicArray[10] == "bam");
        }

        [TestMethod()]
        public void InsertInsideArrayTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            dynamicArray.Insert(1, "bam");


            Assert.IsTrue((string)dynamicArray[0] == "a");
            Assert.IsTrue((string)dynamicArray[1] == "bam");
            Assert.IsTrue((int)dynamicArray[2] == 14);
            Assert.IsTrue((char)dynamicArray[3] == '3');
        }

        [TestMethod()]
        public void RemoveAtZeroTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            dynamicArray.RemoveAt(0);

            Assert.IsTrue((int)dynamicArray[0] == 14);
            Assert.IsTrue((char)dynamicArray[1] == '3');
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            dynamicArray.RemoveAt(1);

            Assert.IsTrue((string)dynamicArray[0] == "a");
            Assert.IsTrue((char)dynamicArray[1] == '3');
        }

        [TestMethod()]
        public void RemoveAtLastTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            dynamicArray.RemoveAt(2);

            Assert.IsTrue((string)dynamicArray[0] == "a");
            Assert.IsTrue((int)dynamicArray[1] == 14);
        }

        [TestMethod()]
        public void RemoveAtBeyondTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            dynamicArray.RemoveAt(3);

            Assert.IsTrue((string)dynamicArray[0] == "a");
            Assert.IsTrue((int)dynamicArray[1] == 14);
            Assert.IsTrue((char)dynamicArray[2] == '3');
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            int index0 = dynamicArray.IndexOf("a");
            int index1 = dynamicArray.IndexOf(14);
            int index2 = dynamicArray.IndexOf('3');

            Assert.AreEqual(0, index0);
            Assert.AreEqual(1, index1);
            Assert.AreEqual(2, index2);
        }

        [TestMethod()]
        public void IndexOfNoMatchTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            int index = dynamicArray.IndexOf("bbb");

            Assert.AreEqual(-1, index);
        }

        [TestMethod()]
        public void IndexOfSameItemsTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            dynamicArray.Add(14);
            int index1 = dynamicArray.IndexOf(14);

            dynamicArray.RemoveAt(1);
            int index2 = dynamicArray.IndexOf(14);

            Assert.AreEqual(1, index1);
            Assert.AreEqual(2, index2);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            dynamicArray.Remove(14);

            Assert.IsTrue((string)dynamicArray[0] == "a");
            Assert.IsTrue((char)dynamicArray[1] == '3');
        }

        [TestMethod()]
        public void RemoveNoMatchTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            dynamicArray.Remove("bbb");

            Assert.IsTrue((string)dynamicArray[0] == "a");
            Assert.IsTrue((int)dynamicArray[1] == 14);
            Assert.IsTrue((char)dynamicArray[2] == '3');
        }

        [TestMethod()]
        public void ContainsTrueTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            bool contains = dynamicArray.Contains('3');

            Assert.IsTrue(contains);
        }

        [TestMethod()]
        public void ContainsFalseTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            bool contains = dynamicArray.Contains("bbb");

            Assert.IsFalse(contains);
        }

        [TestMethod()]
        public void ReverseTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            dynamicArray.Reverse();

            Assert.IsTrue((string)dynamicArray[2] == "a");
            Assert.IsTrue((int)dynamicArray[1] == 14);
            Assert.IsTrue((char)dynamicArray[0] == '3');
        }

        [TestMethod()]
        public void ClearTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            dynamicArray.Clear();

            Assert.AreEqual(0, dynamicArray.Count);
        }

        [TestMethod()]
        public void IndexerSetTest()
        {
            DynamicArray dynamicArray = CreateTestArray();

            dynamicArray[2] = 15;

            Assert.IsTrue((int)dynamicArray[2] == 15);
        }
    }
}
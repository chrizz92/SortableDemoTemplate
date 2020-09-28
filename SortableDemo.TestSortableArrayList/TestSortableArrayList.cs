using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortableDemo.Core;
using System;

namespace SortableDemo.TestCore
{
    class Pet : IComparable
    {
        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int CompareTo(object other)
        {
            return this._age.CompareTo((other as Pet)._age);
        }
    }
    [TestClass]
    public class TestSortableArrayList
    {
        [TestMethod]
        public void T01_CreateEmptyList_CountShouldReturn0()
        {
            SortableArrayList list = new SortableArrayList();
            Assert.AreEqual(0, list.Count());
        }

        [TestMethod]
        public void T02_AddItems_TestCount()
        {
            SortableArrayList list = new SortableArrayList();
            list.Add("Item1");
            Assert.AreEqual(1, list.Count(), "Count should return 1 after first add");
            list.Add("Item2");
            Assert.AreEqual(2, list.Count(), "Count should return 2 after second add");
        }

        [TestMethod]
        public void T03_InsertItems_TestCount()
        {
            SortableArrayList list = new SortableArrayList();
            list.Insert(0,"Item1");
            Assert.AreEqual(1, list.Count(), "Count should return 1 after first insert");
            list.Insert(0,"Item2");
            Assert.AreEqual(2, list.Count(), "Count should return 2 after second insert");
            list.Insert(1, "Item3");
            Assert.AreEqual(3, list.Count(), "Count should return 3 after third insert");
        }

        [TestMethod]
        public void T04_AddItems_TestIndexer()
        {
            string item1 = "Item1";
            string item2 = "Item2";
            string item3 = "Item3";
            SortableArrayList list = new SortableArrayList();
            list.Add(item1);
            Assert.AreEqual(1, list.Count(), "Count should return 1 after first add");
            list.Add(item2);
            Assert.AreEqual(2, list.Count(), "Count should return 2 after second add");
            list.Add(item3);
            Assert.AreEqual(3, list.Count(), "Count should return 3 after thirs add");
            Assert.AreEqual(item1, list[0], "list[0] should return Item1");
        }

        [TestMethod]
        public void T05_SortItems()
        {
            Pet pet1 = new Pet() { Age = 10 };
            Pet pet2 = new Pet() { Age = 7 };
            Pet pet3 = new Pet() { Age = 1 };
            Pet pet4 = new Pet() { Age = 8 };
            Pet pet5 = new Pet() { Age = 11 };
            SortableArrayList list = new SortableArrayList();
            list.Add(pet1);
            list.Add(pet2);
            list.Add(pet3);
            list.Add(pet4);
            list.Add(pet5);
            list.Sort();
            Assert.AreEqual(pet3, list[0], "pet3 should be on first position");
            Assert.AreEqual(pet2, list[1], "pet2 should be on second position");
            Assert.AreEqual(pet4, list[2], "pet4 should be on third position");
            Assert.AreEqual(pet1, list[3], "pet1 should be on fourth position");
            Assert.AreEqual(pet5, list[4], "pet5 should be on fifth position");
        }

        [TestMethod]
        public void T06_ReverseListWith5Items()
        {
            Pet pet1 = new Pet() { Age = 10 };
            Pet pet2 = new Pet() { Age = 7 };
            Pet pet3 = new Pet() { Age = 1 };
            Pet pet4 = new Pet() { Age = 8 };
            Pet pet5 = new Pet() { Age = 11 };
            SortableArrayList list = new SortableArrayList();
            list.Add(pet1);
            list.Add(pet2);
            list.Add(pet3);
            list.Add(pet4);
            list.Add(pet5);
            list.Reverse();
            Assert.AreEqual(pet5, list[0], "pet5 should be on first position");
            Assert.AreEqual(pet4, list[1], "pet4 should be on second position");
            Assert.AreEqual(pet3, list[2], "pet3 should be on third position");
            Assert.AreEqual(pet2, list[3], "pet2 should be on fourth position");
            Assert.AreEqual(pet1, list[4], "pet1 should be on fifth position");


        }

        [TestMethod]
        public void T07_ReverseListWith4Items()
        {
            Pet pet1 = new Pet() { Age = 10 };
            Pet pet2 = new Pet() { Age = 7 };
            Pet pet3 = new Pet() { Age = 1 };
            Pet pet4 = new Pet() { Age = 8 };
            SortableArrayList list = new SortableArrayList();
            list.Add(pet1);
            list.Add(pet2);
            list.Add(pet3);
            list.Add(pet4);
            list.Reverse();
            Assert.AreEqual(pet4, list[0], "pet4 should be on first position");
            Assert.AreEqual(pet3, list[1], "pet3 should be on second position");
            Assert.AreEqual(pet2, list[2], "pet2 should be on third position");
            Assert.AreEqual(pet1, list[3], "pet1 should be on fourth position");
        }

        [TestMethod]
        public void T08_RemoveItem_WhichIsNotInList()
        {
            Pet pet1 = new Pet() { Age = 10 };
            Pet pet2 = new Pet() { Age = 7 };
            Pet pet3 = new Pet() { Age = 1 };
            Pet pet4 = new Pet() { Age = 8 };
            Pet pet5 = new Pet() { Age = 11 };
            SortableArrayList list = new SortableArrayList();
            list.Add(pet1);
            list.Add(pet2);
            list.Add(pet3);
            list.Add(pet4);
            Assert.AreEqual(4, list.Count(), "Count not working properly");
            Assert.IsFalse(list.Remove(pet5),"Remove should return false");
            Assert.AreEqual(4, list.Count(), "Count should not be reduced, when no object is removed");
        }

        [TestMethod]
        public void T09_RemoveItem_WhichIsInList()
        {
            Pet pet1 = new Pet() { Age = 10 };
            Pet pet2 = new Pet() { Age = 7 };
            Pet pet3 = new Pet() { Age = 1 };
            Pet pet4 = new Pet() { Age = 8 };
            Pet pet5 = new Pet() { Age = 11 };
            SortableArrayList list = new SortableArrayList();
            list.Add(pet1);
            list.Add(pet2);
            list.Add(pet3);
            list.Add(pet4);
            Assert.IsTrue(list.Remove(pet3),"Should return true");
            Assert.AreEqual(3, list.Count(), "Count should be reduced");
        }

        [TestMethod]
        public void T10_RemoveItem_WhichIsDuplicateInList()
        {
            Pet pet1 = new Pet() { Age = 10 };
            Pet pet2 = new Pet() { Age = 7 };
            Pet pet3 = new Pet() { Age = 1 };
            Pet pet4 = new Pet() { Age = 8 };
            Pet pet5 = new Pet() { Age = 11 };
            SortableArrayList list = new SortableArrayList();
            list.Add(pet1);
            list.Add(pet2);
            list.Add(pet3);
            list.Add(pet4);
            list.Add(pet3);
            Assert.IsTrue(list.Remove(pet3), "Should return true");
            Assert.AreEqual(4, list.Count(), "Count should be reduced by 1");
            Assert.AreEqual(pet3, list[3], "Second occurence of pet3 should not be deleted");
        }

        [TestMethod]
        public void T11_RemoveAt()
        {
            Pet pet1 = new Pet() { Age = 10 };
            Pet pet2 = new Pet() { Age = 7 };
            Pet pet3 = new Pet() { Age = 1 };
            Pet pet4 = new Pet() { Age = 8 };
            Pet pet5 = new Pet() { Age = 11 };
            SortableArrayList list = new SortableArrayList();
            list.Add(pet1);
            list.Add(pet2);
            list.Add(pet3);
            list.Add(pet4);
            list.RemoveAt(2);
            Assert.AreEqual(3, list.Count(), "Count should be reduced");

            Assert.AreEqual(pet1, list[0], "pet1 should be on first position");
            Assert.AreEqual(pet2, list[1], "pet2 should be on second position");
            Assert.AreEqual(pet4, list[2], "pet4 should be on third position");

            list.RemoveAt(2);
            Assert.AreEqual(2, list.Count(), "Count should be reduced");
            Assert.AreEqual(pet1, list[0], "pet1 should be on first position");
            Assert.AreEqual(pet2, list[1], "pet2 should be on second position");

            list.RemoveAt(0);
            Assert.AreEqual(1, list.Count(), "Count should be reduced");
            Assert.AreEqual(pet2, list[0], "pet2 should be on first position");

            list.RemoveAt(0);
            Assert.AreEqual(0, list.Count(), "Count should be reduced");

            list.Add(pet4);
            Assert.AreEqual(pet4, list[0], "pet4 should be on first position");
        }

        [TestMethod]
        public void T12_Insert()
        {
            Pet pet1 = new Pet() { Age = 10 };
            Pet pet2 = new Pet() { Age = 7 };
            Pet pet3 = new Pet() { Age = 1 };
            Pet pet4 = new Pet() { Age = 8 };
            Pet pet5 = new Pet() { Age = 11 };
            SortableArrayList list = new SortableArrayList();
            list.Insert(0,pet1);
            Assert.AreEqual(pet1, list[0], "pet1 should be on first position");

            list.Insert(1, pet2);
            Assert.AreEqual(pet2, list[1], "pet2 should be on second position");

            list.Insert(1, pet3);
            Assert.AreEqual(pet1, list[0], "pet1 should be on first position");
            Assert.AreEqual(pet3, list[1], "pet3 should be on second position");
            Assert.AreEqual(pet2, list[2], "pet2 should be on third position");

        }

    }
}

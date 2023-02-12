using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class SnakeListTests {
        const int initialSnakeListCount = 1;

        static SnakePoint InitialHead => new SnakePoint(2, 3);
        static SnakePoint NewHead => new SnakePoint(1, 1);

        static SnakeList CreateSnakeList() {
            return new SnakeList(InitialHead);
        }

        static SnakeList CreateSnakeListAndAdd() {
            var list = CreateSnakeList();
            list.AddHead(NewHead);
            return list;
        }
        
        [Test]
        public void CreateSnakeListTest() {
            var list = CreateSnakeList();
            Assert.AreEqual(initialSnakeListCount, list.Count);
            Assert.AreEqual(InitialHead, list.Head);
        }

        [Test]
        public void AddHeadTest() {
            const int listCountAfterAdd = 2;
            var list = CreateSnakeListAndAdd();
            Assert.AreEqual(listCountAfterAdd, list.Count);
            Assert.AreEqual(NewHead, list.Head);
            Assert.AreEqual(InitialHead, list.Tail);
        }

        [Test]
        public void RemoveTailTest() {
            var list = CreateSnakeListAndAdd();
            list.RemoveTail();
            Assert.AreEqual(initialSnakeListCount, list.Count);
            Assert.AreEqual(NewHead, list.Tail);
        }
    }
}

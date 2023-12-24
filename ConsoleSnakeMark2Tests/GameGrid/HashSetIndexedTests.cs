using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class HashSetIndexedTests {
        static Point CreatePoint1() {
            const int coordinate = 0;
            return new Point(coordinate, coordinate);
        }

        static Point CreatePoint2() {
            const int coordinate = 1;
            return new Point(coordinate, coordinate);
        }

        static HashSetIndexed Create2PointSet() {
            HashSetIndexed set = new HashSetIndexed();
            set.Add(CreatePoint1());
            set.Add(CreatePoint2());
            return set;
        }
        
        [Test]
        public void AddTest() {
            HashSetIndexed set = new HashSetIndexed();
            Point point = CreatePoint1();
            set.Add(point);
            Assert.AreEqual(1, set.Count);
            Assert.AreEqual(point, set[0]);
        }

        [Test]
        public void IndexerTest() {
            Assert.IsNotNull(Create2PointSet()[0]);
        }

        [Test]
        public void RemoveTest() {
            HashSetIndexed set = Create2PointSet();
            Assert.AreEqual(2, set.Count);
            set.Remove(CreatePoint2());
            Assert.AreEqual(1, set.Count);
            Assert.AreEqual(CreatePoint1(), set[0]);
        }
    }
}
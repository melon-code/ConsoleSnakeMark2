using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class PointTests {
        const int point1X = 3;
        const int point1Y = 6;
        const int point2X = 2;
        const int point2Y = 1;
        
        static Point CreatePoint1() {
            return new Point(point1X, point1Y);
        }

        static Point CreatePoint2() {
            return new Point(point2X, point2Y);
        }

        static void HashCodeNotEqualTest(Point point1, Point point2) {
            Assert.AreNotEqual(point1.GetHashCode(), point2.GetHashCode());
        }

        [Test]
        public void PointInitTest() {
            Point point = CreatePoint1();
            Assert.AreEqual(point.X, point1X);
            Assert.AreEqual(point.Y, point1Y);
        }

        [Test]
        public void GetHashCodeTest() {
            Point point1 = CreatePoint1();
            Point point2 = CreatePoint1();
            Assert.AreEqual(point1.GetHashCode(), point2.GetHashCode());
            HashCodeNotEqualTest(point1, CreatePoint2());
        }

        [Test]
        public void GetHashCodeMirrorPointsTest() {
            const int x = 1;
            const int y = 2;
            HashCodeNotEqualTest(new Point(x, y), new Point(y, x));
        }

        [Test]
        public void GetHashCodeDiagonalPointsTest() {
            const int xy1 = 1;
            const int xy2 = 2;
            HashCodeNotEqualTest(new Point(xy1, xy1), new Point(xy2, xy2));
        }

        [Test]
        public void EqualityOperatorTest() {
            Point point1 = CreatePoint1();
            Assert.IsTrue(point1 == CreatePoint1());
            Assert.IsFalse(point1 == CreatePoint2());
        }

        [Test]
        public void EqualityOperatorNullTest() {
            Assert.IsFalse(CreatePoint1() == null);
            Assert.IsFalse(null == CreatePoint1());
        }

        [Test]
        public void EqualsTest() {
            Point point1 = CreatePoint1();
            Assert.IsTrue(point1.Equals(CreatePoint1()));
            Assert.IsFalse(point1.Equals(CreatePoint2()));
        }
    }
}

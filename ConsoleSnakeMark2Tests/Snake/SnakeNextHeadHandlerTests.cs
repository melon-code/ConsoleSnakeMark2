using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class SnakeNextHeadHandlerTests {
        static SnakePoint InitialPoint => new SnakePoint(2, 2);
        static SnakePoint NextPoint => InitialPoint.GetNextSnakePoint(Direction.Right);

        static SnakeNextHeadHandler CreateHeadHandler() {
            return new SnakeNextHeadHandler(new SnakeList(InitialPoint), Direction.Right);
        }
        
        static void IsOppositeTest(bool expected, Direction direction1, Direction direction2) {
            const string methodName = "IsOpposite";
            Assert.AreEqual(expected, TestExtensionMethods.InvokeStaticMethod<bool>(typeof(SnakeNextHeadHandler), methodName, direction1, direction2));
        }
        
        [TestCase(Direction.Left, Direction.Right)]
        [TestCase(Direction.Up, Direction.Down)]
        public void IsOppositeTrueTest(Direction direction1, Direction direction2) {
            IsOppositeTest(true, direction1, direction2);
        }

        [TestCase(Direction.Left, Direction.Up)]
        [TestCase(Direction.Left, Direction.Down)]
        [TestCase(Direction.Right, Direction.Up)]
        [TestCase(Direction.Right, Direction.Up)]
        public void IsOppositeFalseTest(Direction direction1, Direction direction2) {
            IsOppositeTest(false, direction1, direction2);
        }

        [TestCase(Direction.Right, Direction.Left)]
        [TestCase(Direction.Up, Direction.Up)]
        public void SetNewHeadDirectionTest(Direction expected, Direction setDirection) {
            var handler = CreateHeadHandler();
            handler.SetNewHeadDirection(setDirection);
            Assert.AreEqual(expected, handler.Direction);
        }

        [Test]
        public void SetTeleportedHeadTest() {
            const string boolName = "isTeleported";
            const string pointName = "teleportedHead";
            Point teleportedHead = new Point(4, 6);
            var handler = CreateHeadHandler();
            handler.SetTeleportedHead(teleportedHead);
            Assert.IsTrue(handler.GetFieldValue<bool>(boolName));
            Assert.AreEqual(teleportedHead, handler.GetFieldValue<Point>(pointName));
        }

        [Test]
        public void GetNextHeadTest() {
            var handler = CreateHeadHandler();
            Assert.AreEqual(NextPoint, handler.GetNextHead());
        }

        [Test]
        public void GetNextHeadTeleportedTest() {
            Point teleported = new Point(2, 6);
            var handler = CreateHeadHandler();
            handler.SetTeleportedHead(teleported);
            Assert.AreEqual(teleported, handler.GetNextHead());
            Assert.AreEqual(NextPoint, handler.GetNextHead());
        }
    }
}

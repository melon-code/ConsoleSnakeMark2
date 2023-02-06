using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class SnakePointTests {
        [TestCase(Direction.Left, 3, 3)]
        [TestCase(Direction.Right, 3, 5)]
        [TestCase(Direction.Up, 2, 4)]
        [TestCase(Direction.Down, 4, 4)]
        public void GetNextSnakePointTest(Direction direction, int resX, int resY) {
            const int x = 3;
            const int y = 4;
            Assert.IsTrue(new SnakePoint(x, y).GetNextSnakePoint(direction) == new Point(resX, resY));
        }
    }
}
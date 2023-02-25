using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class GameGridTests {
        [TestCase(4, 4, 4)]
        [TestCase(5, 4, 6)]
        [TestCase(7, 5, 15)]
        public void CapacityTest(int height, int width, int expectedCapacity) {
            GameGrid grid = new GameGrid(height, width);
            Assert.AreEqual(expectedCapacity, grid.Capacity);
        }
    }
}

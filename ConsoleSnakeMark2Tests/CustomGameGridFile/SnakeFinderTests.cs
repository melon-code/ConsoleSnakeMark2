using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class SnakeFinderTests {
        const int height = 10;
        const int width = 8;

        static Point DefaultSnakePosiotion => GameData.DefaultSnakePosition(height, width);

        static void AssertSnakeFinder(SnakeFinder finder, Direction expectedDirection, Point expectedPosition) {
            Assert.AreEqual(expectedDirection, finder.Direction);
            Assert.AreEqual(expectedPosition, finder.GetPosition(height, width));
        }
        
        static void TryFindSnakeBase(string line, int lineNumber, Direction expectedDirection, Point expectedPosition) {
            SnakeFinder finder = new SnakeFinder();
            finder.TryFindSnake(line, lineNumber);
            AssertSnakeFinder(finder, expectedDirection, expectedPosition);
        }

        static void MultipleLinesBase(IList<string> grid, Direction expectedDirection, Point expectedPosition) {
            SnakeFinder finder = new SnakeFinder();
            for (int i = 0; i < grid.Count; i++)
                finder.TryFindSnake(grid[i], i);
            AssertSnakeFinder(finder, expectedDirection, expectedPosition);
        }

        [TestCase()]
        public void TryFindSnakeTest() {
            const int number = 4;
            const int snakeIndex = 3;
            string line = "BB " + ParsingData.SnakeUp.ToString() + " B";
            TryFindSnakeBase(line, number, Direction.Up, new Point(number, snakeIndex));
        }

        [Test]
        public void NoSnakeTest() {
            string line = "BBBBB";
            TryFindSnakeBase(line, 1, GameData.DefaultSnakeDirection, DefaultSnakePosiotion);
        }

        [Test]
        public void MultipleLinesTest() {
            const int snakeLineIndex = 2, snakeSymbolIndex = 3;
            const string noSnakeLine = "B    B";
            string snakeLine = "B  " + ParsingData.SnakeLeft.ToString() + " B";
            MultipleLinesBase(new List<string>() { noSnakeLine, noSnakeLine, snakeLine, noSnakeLine }, Direction.Left, new Point(snakeLineIndex, snakeSymbolIndex));
        }

        [Test]
        public void MultipleLinesNoSnakeTest() {
            const string noSnakeLine = "BB  BBo BB";
            MultipleLinesBase(new List<string>() { noSnakeLine, noSnakeLine, noSnakeLine }, GameData.DefaultSnakeDirection, DefaultSnakePosiotion);
        }
    }
}

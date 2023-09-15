using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class GridInitializerTests {
        const int height = 10;
        const int width = 15;

        static void CellTest<T>(int x, int y, bool portalBorders) {
            Assert.IsInstanceOf<T>(GridInitializer.InitializeCell(x, y, portalBorders, height, width));
        }

        static bool IsBorder(int x, int y) {
            if (x == 0 || y == 0 || x == height - 1 || y == width - 1)
                return true;
            return false;
        }

        static Type GetCellType<T>(int x, int y) {
            return IsBorder(x, y) ? typeof(T) : typeof(EmptyCell);
        }

        static void CheckGrid<T>(bool portalBorders) {
            ICell[,] grid = new ICell[height, width];
            GridInitializer.InitializeGrid(height, width, portalBorders, (point, cell) => grid[point.X, point.Y] = cell);
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    Assert.IsInstanceOf(GetCellType<T>(i, j), grid[i, j]);
        }

        [TestCase(0, 0)]
        [TestCase(0, 5)]
        [TestCase(6, 0)]
        [TestCase(7, width - 1)]
        [TestCase(height - 1, 5)]
        [TestCase(height - 1, width - 1)]
        public void InitializeCellBorderTest(int x, int y) {
            CellTest<BorderCell>(x, y, false);
            CellTest<PortalBorderCell>(x, y, true);
        }

        [TestCase(0, 4, height - 2, 4)]
        [TestCase(5, 0, 5, width - 2)]
        [TestCase(8, width - 1, 8, 1)]
        [TestCase(height - 1, 3, 1, 3)]
        public void PortalBorderDestinationTest(int x, int y, int dX, int dY) {
            const string name = "destination";
            var portalCell = GridInitializer.InitializeCell(x, y, true, height, width);
            Assert.AreEqual(new Point(dX, dY), portalCell.GetFieldValue<Point>(name));
        }

        [TestCase(4, 8)]
        [TestCase(8, 4)]
        [TestCase(1, 1)]
        public void InitializeCellEmptyTest(int x, int y) {
            CellTest<EmptyCell>(x, y, false);
            CellTest<EmptyCell>(x, y, true);
        }

        [Test]
        public void InitializeGridTest() {
            CheckGrid<BorderCell>(false);
            CheckGrid<PortalBorderCell>(true);
        }
    }
}

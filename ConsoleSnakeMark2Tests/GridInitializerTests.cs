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
            Assert.IsInstanceOf(typeof(T), GridInitializer.InitializeCell(x, y, portalBorders, height, width));
        }

        static bool IsBorder(int x, int y) {
            if (x == 0 || y == 0 || x == height - 1 || y == width - 1) 
                return true;
            return false;
        }

        static void CheckGrid<T>(bool portalBorders) {
            ICell[,] grid = new ICell[height, width];
            GridInitializer.InitializeGrid(height, width, portalBorders, (point, cell) => grid[point.X, point.Y] = cell);
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    if (IsBorder(i, j))
                        Assert.IsInstanceOf<T>(grid[i, j]);
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

        [Test]
        public void InitializeCellEmptyTest() {
            const int indX = 4;
            const int indY = 8;
            CellTest<EmptyCell>(indX, indY, false);
            CellTest<EmptyCell>(indX, indY, true);
        }

        [Test]
        public void InitializeGridTest() {
            CheckGrid<BorderCell>(false);
            CheckGrid<PortalBorderCell>(true);
        }
    }
}

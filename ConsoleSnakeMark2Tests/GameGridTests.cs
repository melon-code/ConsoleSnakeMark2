using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class GameGridTests {
        const int size = 10;

        static void AssertFoodValue(int expectedFoodValue, ICell foodCell) {
            const string foodValueFieldName = "value";
            Assert.AreEqual(expectedFoodValue, foodCell.GetFieldValue<int>(foodValueFieldName));
        }

        [TestCase(4, 4, 4)]
        [TestCase(5, 4, 6)]
        [TestCase(7, 5, 15)]
        public void CapacityTest(int height, int width, int expectedCapacity) {
            GameGrid grid = new GameGrid(height, width);
            Assert.AreEqual(expectedCapacity, grid.Capacity);
        }
                
        [TestCase(TestConst.SmallFoodValue)]
        [TestCase(5)]
        public void AddFoodEmptyCellTest(int foodValue) {
            Point point = new Point(2, 2);
            GameGrid grid = new GameGrid(size);
            Assert.IsTrue(grid.AddFood(point, foodValue));
            ICell cell = grid[point];
            Assert.IsInstanceOf<FoodCell>(cell);
            AssertFoodValue(foodValue, cell);
        }

        [Test]
        public void AddFoodFalseTest() {
            Point point = new Point(0, 0);
            GameGrid grid = new GameGrid(size);
            Assert.IsFalse(grid.AddFood(point, TestConst.SmallFoodValue));
            Assert.IsNotInstanceOf<FoodCell>(grid[point]);
        }

        [TestCase(TestConst.SmallFoodValue)]
        [TestCase(4)]
        public void AddFoodRandomPlaceTest(int foodValue) {
            GameGrid grid = new GameGrid(size);
            grid.AddFoodRandomPlace(foodValue);
            Assert.IsTrue(GridTestHelper.TryFindFoodPoint(grid, out Point food));
            AssertFoodValue(foodValue, grid[food]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class CellTests {
        static void GetCollisionBehaviorParametersTest<T>(ICell cell, Type expectedParametersType, T expectedParameterValue) {
            const string parameterValueName = "value";
            var collisionParameters = cell.GetCollisionBehaviorParameters();
            Assert.IsInstanceOf(expectedParametersType, collisionParameters);
            Assert.AreEqual(expectedParameterValue, collisionParameters.GetFieldValue<T>(parameterValueName));
        }
        
        static void GetCollisionBehaviorParametersTest<T>(CellType cellType, Type expectedParametersType, T expectedParameterValue) {
            GetCollisionBehaviorParametersTest(CellFactory.CreateCell(cellType), expectedParametersType, expectedParameterValue);
        }

        static void GetCollisionBehaviorTypeParametersTest(CellType cellType, CollisionBehaviorType collisionBehaviorType) {
            GetCollisionBehaviorParametersTest(cellType, typeof(CollisionBehaviorTypeParameter), collisionBehaviorType);
        }

        [Test]
        public void EmptyCellTest() {
            GetCollisionBehaviorTypeParametersTest(CellType.Empty, CollisionBehaviorType.Continue);
        }

        [Test]
        public void BorderCellTest() {
            GetCollisionBehaviorTypeParametersTest(CellType.Border, CollisionBehaviorType.EndGame);
        }

        [TestCase(CellType.SnakeHead)]
        [TestCase(CellType.SnakeBody)]
        [TestCase(CellType.SnakeTailStatic)]
        public void SnakeCellsTest(CellType snakeCellType) {
            GetCollisionBehaviorTypeParametersTest(snakeCellType, CollisionBehaviorType.EndGame);
        }

        [Test]
        public void SnakeMovingTailCellTest() {
            GetCollisionBehaviorTypeParametersTest(CellType.SnakeTailMoving, CollisionBehaviorType.Continue);
        }

        [Test]
        public void FoodCellTest() {
            const int foodValue = 1;
            GetCollisionBehaviorParametersTest(CellType.Food, typeof(FoodBehaviorParameters), foodValue);
        }

        [Test]
        public void PortalBorderCellTest() {
            const int x = 2;
            const int y = 4;
            Point destination = new Point(x, y);
            GetCollisionBehaviorParametersTest(new PortalBorderCell(destination), typeof(PortalBorderBehaviorParameters), destination);
        }
    }
}

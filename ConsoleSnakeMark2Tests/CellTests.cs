using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class CellTests {
        static void GetCollisionBehaviorParametersTest(CellType cellType, Type expectedParametersType) {
            Assert.IsInstanceOf(expectedParametersType, CellFactory.CreateCell(cellType).GetCollisionBehaviorParameters());
        }

        static void GetCollisionBehaviorTypeParametersTest(CellType cellType, CollisionBehaviorType collisionBehaviorType) {
            const string fieldName = "value";
            var collisioTypeParameters = CellFactory.CreateCell(cellType).GetCollisionBehaviorParameters();
            Assert.AreEqual(collisionBehaviorType, collisioTypeParameters.GetFieldValue<CollisionBehaviorType>(fieldName));
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
            GetCollisionBehaviorParametersTest(CellType.Food, typeof(FoodBehaviorParameters));
        }

        [Test]
        public void PortalBorderCellTest() {
            GetCollisionBehaviorParametersTest(CellType.PortalBorder, typeof(PortalBorderBehaviorParameters));
        }
    }
}

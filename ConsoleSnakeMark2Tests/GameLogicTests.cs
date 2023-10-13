using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class GameLogicTests {
        const int height = 10;
        const int width = 12;

        static Point Center = new Point(height / 2, width / 2);
        
        static GameLogic CreateLogic(Point snakeHead, int gridHeight = height, int gridWidth = width) {
            return new GameLogic(new GameGrid(gridHeight, gridWidth), new Snake(snakeHead));
        }

        static void AssertGameOver(GameLogic logic) {
            const string fieldName = "gameOver";
            Assert.IsTrue(logic.GetFieldValue<bool>(fieldName));
            Assert.IsTrue(logic.IsEnd);
        }

        static void MoveSnake(GameLogic logic, Direction direction = Direction.Right) {
            logic.CurrentSnakeDirection = direction;
            logic.Iterate();
        }

        static void WinTestBase(int iterations) {
            GameLogic logic = CreateLogic(new Point(1, 1), 3, 4);
            for (int i = 0; i < iterations; i++)
                logic.Iterate();
            Assert.IsTrue(logic.GetPropertyValue<bool>("IsWin"));
            Assert.IsTrue(logic.IsEnd);
        }

        static void EatFoodAndMoveInCircle(out GameLogic logic, int foodValue, int iterationsBeforeCircle) {
            logic = CreateLogic(Center);
            logic.SpawnFood(new Point(Center.X, Center.Y + 1), foodValue);
            for (int i = 0; i < iterationsBeforeCircle; i++)
                MoveSnake(logic);
            MoveSnake(logic, Direction.Up);
            MoveSnake(logic, Direction.Left);
            MoveSnake(logic, Direction.Down);
        }

        [Test]
        public void GameOverBorderTest() {
            GameLogic logic = CreateLogic(new Point(height / 2, width - 2));
            logic.Iterate();
            AssertGameOver(logic);
        }

        [Test]
        public void GameOverSnakeTest() {
            const int bigFoodValue = 10;
            EatFoodAndMoveInCircle(out GameLogic logic, bigFoodValue, 4);
            AssertGameOver(logic);
        }

        [Test]
        public void IterateAfterGameOverTest() {
            GameLogic logic = CreateLogic(Center);
            for (int i = 0; i < width; i++)
                logic.Iterate();
            AssertGameOver(logic);
        }

        [Test]
        public void WinTest() {
            WinTestBase(1);
        }

        [Test]
        public void IterateAfterWinTest() {
            WinTestBase(5);
        }

        [Test]
        public void MovingSnakeTailTest() {
            const int bigFoodValue = 3;
            EatFoodAndMoveInCircle(out GameLogic logic, bigFoodValue, 1);
            Assert.IsFalse(logic.IsEnd);
        }

        [Test]
        public void StaticSnakeTailTest() {
            const int bigFoodValue = 4;
            EatFoodAndMoveInCircle(out GameLogic logic, bigFoodValue, 1);
            AssertGameOver(logic);
        }
    }
}

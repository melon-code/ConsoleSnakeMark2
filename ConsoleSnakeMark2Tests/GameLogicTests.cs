using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class GameLogicTests {
        const int height = GameLogicTestWrap.Height;
        const int width = GameLogicTestWrap.Width;

        static void AssertGameOver(GameLogicTestWrap logic) {
            Assert.IsTrue(logic.GameOver);
            Assert.IsTrue(logic.IsEnd);
        }

        static void WinTestBase(int iterations) {
            GameLogicTestWrap logic = new GameLogicTestWrap(new Point(1, 1), 3, 4);
            for (int i = 0; i < iterations; i++)
                logic.MoveSnakeWithCollision();
            Assert.IsTrue(logic.IsWin);
            Assert.IsTrue(logic.IsEnd);
        }

        static void EatFoodAndMoveInCircle(out GameLogicTestWrap logic, int foodValue, int iterationsBeforeCircle) {
            logic = new GameLogicTestWrap();
            logic.EatFood(foodValue);
            for (int i = 0; i < iterationsBeforeCircle; i++)
                logic.MoveSnakeWithoutCollision();
            logic.MoveSnakeWithoutCollision(Direction.Up);
            logic.MoveSnakeWithoutCollision(Direction.Left);
            logic.MoveSnakeWithCollision(Direction.Down);
        }

        [Test]
        public void GameOverBorderTest() {
            GameLogicTestWrap logic = new GameLogicTestWrap(new Point(height / 2, width - 2));
            logic.MoveSnakeWithCollision();
            AssertGameOver(logic);
        }

        [Test]
        public void GameOverSnakeTest() {
            const int bigFoodValue = 10;
            EatFoodAndMoveInCircle(out GameLogicTestWrap logic, bigFoodValue, 4);
            AssertGameOver(logic);
        }

        [Test]
        public void IterateAfterGameOverTest() {
            GameLogicTestWrap logic = new GameLogicTestWrap();
            for (int i = 0; i < width; i++)
                logic.MoveSnakeWithCollision();
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
            EatFoodAndMoveInCircle(out GameLogicTestWrap logic, bigFoodValue, 1);
            Assert.IsFalse(logic.IsEnd);
        }

        [Test]
        public void StaticSnakeTailTest() {
            const int bigFoodValue = 4;
            EatFoodAndMoveInCircle(out GameLogicTestWrap logic, bigFoodValue, 1);
            AssertGameOver(logic);
        }

        [Test]
        public void CurrentDirectionTest() {
            Direction initialDirection = Direction.Left;
            GameLogic logic = new GameLogic(new GameGrid(height, width), new Snake(GameLogicTestWrap.Center, initialDirection));
            logic.CurrentSnakeDirection = Direction.Right;
            logic.SetCurrentDirection();
            Assert.AreEqual(initialDirection, logic.CurrentSnakeDirection);
        }
    }
}

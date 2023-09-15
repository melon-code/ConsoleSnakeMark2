using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class GameGridTests {
        const int height = 12;
        const int width = 16;
        const int onlyHeadLength = 1;
        const int onlyHeadTailLength = 2;

        static int InitialX => height / 2;
        static SnakePoint InitialHead => new SnakePoint(InitialX, width / 2);

        static void ExtendSnake(Snake snake, int value) {
            snake.Eat(value);
            for (int i = 0; i < value; i++)
                snake.Move();
        }

        static GameGrid CreateGameGrid(Point head, out Snake snake, int addSnakeLength = 0) {
            GameGrid grid = new GameGrid(height, width);
            snake = new Snake(head);
            grid.BoundSnake(snake);
            if (addSnakeLength > 0)
                ExtendSnake(snake, addSnakeLength);
            return grid;
        }

        static GameGrid CreateGameGrid(out Snake snake, int addSnakeLength = 0) {
            return CreateGameGrid(InitialHead, out snake, addSnakeLength);
        }

        static bool CheckSnake<SnakeTailType>(Point target, ICell item, Snake snake) {
            if (target == snake.Head) {
                Assert.IsInstanceOf<SnakeHeadCell>(item);
                return true;
            }
            int length = snake.Length;
            if (length > onlyHeadTailLength && snake.GetBody().Contains(target)) {
                Assert.IsInstanceOf<SnakeBodyCell>(item);
                return true;
            }
            if (length > onlyHeadLength && target == snake.GetTail()) {
                Assert.IsInstanceOf<SnakeTailType>(item);
                return true;
            }
            return false;
        }

        static void CheckGrid<SnakeTailType>(GameGrid grid, Snake snake) {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++) {
                    ICell item = grid[i, j];
                    if (!CheckSnake<SnakeTailType>(new Point(i, j), item, snake))
                        Assert.IsNotInstanceOf<SnakeCell>(item);
                }
        }

        static void CheckGrid(GameGrid grid, Snake snake) {
            CheckGrid<SnakeMovingTailCell>(grid, snake);
        }

        static void CheckSnakeMovement(GameGrid grid, Snake snake) {
            const int iterations = 3;
            for (int i = 0; i < iterations; i++) {
                snake.Move();
                CheckGrid(grid, snake);
            }
        }

        [TestCase(4, 4, 4)]
        [TestCase(5, 4, 6)]
        [TestCase(7, 5, 15)]
        public void CapacityTest(int height, int width, int expectedCapacity) {
            GameGrid grid = new GameGrid(height, width);
            Assert.AreEqual(expectedCapacity, grid.Capacity);
        }

        [TestCase(3, 3)]
        [TestCase(2, 6)]
        public void SyncInitialSnakeHeadTest(int x, int y) {
            GameGrid grid = CreateGameGrid(new Point(x, y), out Snake snake);
            CheckGrid(grid, snake);
        }

        [Test]
        public void UpdateOnlyHeadSnakeTest() {
            GameGrid grid = CreateGameGrid(out Snake snake);
            CheckSnakeMovement(grid, snake);
        }

        [Test]
        public void UpdateFirstSnakeExtendTest() {
            GameGrid grid = CreateGameGrid(out Snake snake, TestConst.SmallFoodValue);
            CheckGrid(grid, snake);
        }

        [Test]
        public void MoveHeadTailSnakeTest() {
            GameGrid grid = CreateGameGrid(out Snake snake, TestConst.SmallFoodValue);
            CheckSnakeMovement(grid, snake);
        }

        [TestCase(2)]
        [TestCase(4)]
        public void MoveHeadBodyTailTest(int additionalLenghtToHead) {
            GameGrid grid = CreateGameGrid(new Point(InitialX, 1), out Snake snake, additionalLenghtToHead);
            CheckSnakeMovement(grid, snake);
        }

        [Test]
        public void StaticTailTest() {
            int foodValue = 3;
            GameGrid grid = CreateGameGrid(out Snake snake);
            snake.Eat(foodValue);
            for (int i = 0; i < foodValue - 1; i++) {
                snake.Move();
                CheckGrid<SnakeStaticTailCell>(grid, snake);
            }
            snake.Move();
            CheckGrid(grid, snake);
        }

        [TestCase(Direction.Up)]
        [TestCase(Direction.Down)]
        public void DifferentDirectionsMovementTest(Direction direction) {
            const int iterations = 3;
            GameGrid grid = CreateGameGrid(out Snake snake, iterations);
            snake.SetNewHeadDirection(direction);
            CheckSnakeMovement(grid, snake);
            snake.SetNewHeadDirection(Direction.Left);
            CheckSnakeMovement(grid, snake);
        }
    }
}

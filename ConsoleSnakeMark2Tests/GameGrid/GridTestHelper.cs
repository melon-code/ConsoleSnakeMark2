using ConsoleSnakeMark2;
using NUnit.Framework;

namespace ConsoleSnakeMark2Tests {
    public static class GridTestHelper {
        const int onlyHeadLength = 1;
        const int onlyHeadTailLength = 2;

        static bool AssertSnakeItem<SnakeTailType>(Point target, ICell item, Snake snake) {
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

        public static void AssertSnake<SnakeTailType>(GameGrid grid, Snake expectedSnake) {
            for (int i = 0; i < grid.Height; i++)
                for (int j = 0; j < grid.Width; j++) {
                    ICell item = grid[i, j];
                    if (!AssertSnakeItem<SnakeTailType>(new Point(i, j), item, expectedSnake))
                        Assert.IsNotInstanceOf<SnakeCell>(item);
                }
        }

        public static bool TryFindFoodPoint(GameGrid grid, out Point point) {
            for (int i = 0; i < grid.Height; i++)
                for (int j = 0; j < grid.Width; j++)
                    if (grid[i, j] is FoodCell) {
                        point = new Point(i, j);
                        return true;
                    }
            point = null;
            return false;
        }
    }
}

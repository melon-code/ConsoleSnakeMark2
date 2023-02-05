using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleSnakeMark2 {
    public class GameGrid {
        readonly ICell[,] gameGrid;
        readonly int capacity;
        readonly HashSetIndexed emptyCells;
        readonly RandomPointGenerator pointGenerator;
        Point currentSnakeHead;
        Point currentSnakeTail;

        public ICell this[Point point] => gameGrid[point.X, point.Y];
        public ICell this[int x, int y] => gameGrid[x, y];
        public int Height { get; }
        public int Width { get; }
        public int Capacity => capacity;

        public GameGrid(int height, int width) {
            gameGrid = new ICell[height, width];
            Height = height;
            Width = width;
            capacity = Height * Width - 2 * (Height - 1) - 2 * (Width - 1);
            //grid init
            //add empty cells
            pointGenerator = new RandomPointGenerator(emptyCells);
        }

        void SetItem(Point point, ICell item) {
            if (item.Type != CellType.Empty) {
                gameGrid[point.X, point.Y] = item;
                emptyCells.Remove(point);
            }
        }

        void ReleaseItem(Point point) {
            gameGrid[point.X, point.Y] = new EmptyCell();
            emptyCells.Add(point);
        }

        public void UpdateSnakeHead(Point newHead) {
            SetItem(newHead, new SnakeHeadCell());
            SetItem(currentSnakeHead, new SnakeBodyCell());
            currentSnakeHead = newHead;
        }

        public void UpdateSnakeTail(Point newTail) {
            ReleaseItem(currentSnakeTail);
            if (newTail != currentSnakeHead)
                SetItem(newTail, new SnakeMovingTailCell());
            currentSnakeTail = newTail;
        }

        public void UpdateSnakeTailState(bool extendingNextTurn) {
            SetItem(currentSnakeTail, CellFactory.CreateSnakeTail(extendingNextTurn));
        }

        public void AddRandomFood(int foodValue) {
            SetItem(pointGenerator.GetPoint(), CellFactory.CreateFood(foodValue));
        }
    }
}

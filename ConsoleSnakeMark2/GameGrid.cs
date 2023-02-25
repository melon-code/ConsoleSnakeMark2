using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleSnakeMark2 {
    public class GameGrid {
        readonly ICell[,] grid;
        readonly int capacity;
        readonly HashSetIndexed emptyCells;
        readonly RandomPointGenerator pointGenerator;
        Point currentSnakeHead;
        Point currentSnakeTail;

        public ICell this[Point point] => grid[point.X, point.Y];
        public ICell this[int x, int y] => grid[x, y];
        public int Height { get; }
        public int Width { get; }
        public int Capacity => capacity;

        public GameGrid(int height, int width) : this(height, width, false) {
        }

        public GameGrid(int height, int width, bool portalBorders) {
            grid = new ICell[height, width];
            Height = height;
            Width = width;
            capacity = (Height - 2) * (Width - 2);
            grid = new ICell[height, width];
            emptyCells = new HashSetIndexed();
            GridInitializer.InitializeGrid(height, width, portalBorders, (point, cell) => SetItem(point, cell));
            pointGenerator = new RandomPointGenerator(emptyCells);
        }

        void SetItem(Point point, ICell item) {
            grid[point.X, point.Y] = item;
            if (item.Type == CellType.Empty)
                emptyCells.Add(point);
            else
                emptyCells.Remove(point);
        }

        void SetEmptyItem(Point point) {
            SetItem(point, new EmptyCell());
        }

        public void UpdateSnakeHead(Point newHead) {
            SetItem(newHead, new SnakeHeadCell());
            if (currentSnakeHead != null)
                SetItem(currentSnakeHead, new SnakeBodyCell());
            currentSnakeHead = newHead;
        }

        public void UpdateSnakeTail(Point newTail) {
            if (currentSnakeTail != null) {
                SetEmptyItem(currentSnakeTail);
                if (newTail != currentSnakeHead)
                    SetItem(newTail, new SnakeMovingTailCell());
            }
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

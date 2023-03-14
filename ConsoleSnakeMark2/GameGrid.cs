using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleSnakeMark2 {
    public class GameGrid {
        readonly ICell[,] grid;
        readonly int capacity;
        readonly HashSetIndexed emptyCells;
        readonly RandomPointGenerator pointGenerator;
        readonly SyncSnakeHandler syncHandler;

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
            syncHandler = new SyncSnakeHandler(SetItem);
        }

        void SetItem(Point point, ICell item) {
            grid[point.X, point.Y] = item;
            if (item.Type == CellType.Empty)
                emptyCells.Add(point);
            else
                emptyCells.Remove(point);
        }

        public void BoundSnake(Snake snake) {
            syncHandler.BoundSnake(snake);
        }

        public void AddRandomFood(int foodValue) {
            SetItem(pointGenerator.GetPoint(), CellFactory.CreateFood(foodValue));
        }
    }

    public class SyncSnakeHandler {
        readonly Action<Point, ICell> setItem;
        Point currentSnakeHead;
        Point currentSnakeTail;

        public SyncSnakeHandler(Action<Point, ICell> setGridItem) {
            setItem = setGridItem;
        }

        void SetHead(Point head) {
            setItem(head, new SnakeHeadCell());
        }

        void UpdateSnakeHead(Point newHead) {
            SetHead(newHead);
            setItem(currentSnakeHead, new SnakeBodyCell());
            currentSnakeHead = newHead;
        }

        void UpdateSnakeTail(Point newTail) {
            setItem(currentSnakeTail, new EmptyCell());
            if (newTail != currentSnakeHead)
                setItem(newTail, new SnakeMovingTailCell());
            currentSnakeTail = newTail;
        }

        void UpdateSnakeTailState(bool movingNextTurn) {
            setItem(currentSnakeTail, CellFactory.CreateSnakeTail(movingNextTurn));
        }

        public void BoundSnake(Snake snake) {
            snake.HeadPositionChanged += new Snake.UpdateHeadPositionHandler((point) => UpdateSnakeHead(point));
            snake.TailPositionChanged += new Snake.UpdateTailPositionHandler((point) => UpdateSnakeTail(point));
            snake.TailStateChanged += new Snake.UpdateTailStateHandler((extending) => UpdateSnakeTailState(extending));
            currentSnakeTail = currentSnakeHead = snake.Head;
            SetHead(currentSnakeHead);
        }
    }
}

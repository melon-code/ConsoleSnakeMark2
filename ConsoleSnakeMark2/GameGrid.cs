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

        public GameGrid(int sideSize): this(sideSize, sideSize) {
        }
        
        public GameGrid(int height, int width) : this(height, width, false) {
        }

        public GameGrid(int height, int width, bool portalBorders) {
            Height = Utility.VerifyValue(height, GameData.MinGridHeight, GameData.MaxGridHeight);
            Width = Utility.VerifyValue(width, GameData.MinGridWidth, GameData.MaxGridWidth);
            grid = new ICell[Height, Width];
            capacity = (Height - 2) * (Width - 2);
            grid = new ICell[Height, Width];
            emptyCells = new HashSetIndexed();
            GridInitializer.InitializeGrid(Height, Width, portalBorders, (point, cell) => SetItem(point, cell));
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
        
        public bool AddFood(Point point, int foodValue) {
            if (this[point] is EmptyCell) {
                SetItem(point, CellFactory.CreateFood(foodValue));
                return true;
            }
            return false;
        }

        public void AddFoodRandomPlace(int foodValue) {
            SetItem(pointGenerator.GetPoint(), CellFactory.CreateFood(foodValue));
        }
    }
}

using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    public class GameLogicTestWrap {
        const string snakeName = "snake";
        const string gameOverName = "gameOver";
        const string isWinName = "IsWin";
        public const int Height = 12;
        public const int Width = 14;

        readonly GameLogic logic;
        public static readonly Point Center = new Point(Height / 2, Width / 2);

        Snake Snake => GetValue<Snake>(snakeName);
        public GameGrid Grid => logic.Grid;
        public Direction CurrentDirection => logic.CurrentSnakeDirection;
        public bool GameOver => GetValue<bool>(gameOverName);
        public bool IsWin => logic.GetPropertyValue<bool>(isWinName);
        public bool IsEnd => logic.IsEnd;

        public GameLogicTestWrap(Point snakeHead, int gridHeight = Height, int gridWidth = Width, Direction snakeDirection = GameData.DefaultSnakeDirection) {
            logic = new GameLogic(new GameGrid(gridHeight, gridWidth), new Snake(snakeHead, snakeDirection));
        }

        public GameLogicTestWrap() : this(Center) {
        }

        public GameLogicTestWrap(Direction snakeDirection) : this(Center, Height, Width, snakeDirection) {
        }

        T GetValue<T>(string fieldName) {
            return logic.GetFieldValue<T>(fieldName);
        }

        public void EatFood(int foodValue) {
            Snake.Eat(foodValue);
        }

        public void MoveSnakeWithoutCollision(Direction direction = Direction.Right) {
            Snake.SetNewHeadDirection(direction);
            logic.CurrentSnakeDirection = direction;
            logic.MoveSnake();
        }

        public void MoveSnakeWithCollision(Direction direction = Direction.Right) {
            logic.CurrentSnakeDirection = direction;
            logic.Iterate();
        }
    }
}

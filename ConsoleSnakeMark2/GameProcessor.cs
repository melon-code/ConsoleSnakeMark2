using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeMark2 {
    class GameProcessor {
        const int baseSpeedValue = 1200;
        const int speedRatio = 100;

        static int SpeedToMs(int speed) {
            return baseSpeedValue - Utility.VerifyValue(speed, GameData.MinSpeed, GameData.MaxSpeed) * speedRatio;
        }

        readonly GameLogic gameLogic;
        readonly int interval;
        IConsoleDrawer drawer;

        int SnakeLength => gameLogic.SnakeLength;
        int AteFood => gameLogic.AteFood;
        AdditionalDrawingData DrawingData => new AdditionalDrawingData(gameLogic.CurrentSnakeDirection, SnakeLength, AteFood);
        public SnakeGameStats GameStats => new SnakeGameStats(gameLogic.IsWin, SnakeLength, AteFood);

        GameProcessor(GameGrid grid, Snake snake, int speed) {
            gameLogic = new GameLogic(grid, snake);
            interval = SpeedToMs(speed);
            drawer = new ConsoleDrawer(gameLogic.Grid);
        }

        public GameProcessor(int gridHeight, int gridWidth, bool portalBorders, Point initialSnakePosition, int speed)
            : this(new GameGrid(gridHeight, gridWidth, portalBorders), new Snake(initialSnakePosition), speed) {
        }

        public GameProcessor(int gridHeight, int gridWidth, bool portalBorders, int speed) : this(gridHeight, gridWidth, portalBorders, GameData.DefaultSnakePosition(gridHeight, gridWidth), speed) {
        }

        public GameProcessor(int gridHeight, int gridWidth, bool portalBorders, Point initialSnakePosition) : this(gridHeight, gridWidth, portalBorders, initialSnakePosition, GameData.DefaultSpeed) {
        }

        public GameProcessor(int gridHeight, int gridWidth, bool portalBorders) : this(gridHeight, gridWidth, portalBorders, GameData.DefaultSnakePosition(gridHeight, gridWidth)) {
        }

        public GameProcessor(int gridHeight, int gridWidth) : this(gridHeight, gridWidth, GameData.DefaultPortalBorders) {
        }

        public GameProcessor(ICustomGameGridData data) : this(new GameGrid(data.Height, data.Width, data.GridData), new Snake(data.InitialSnakePosition, data.InitialSnakeDirection), data.Speed) {
        }

        public void StartGameLoop() {
            drawer.SetConsoleWindow();
            drawer.DrawGrid(DrawingData);
            GameLoop gameLoop = new GameLoop(interval, () => {
                gameLogic.Iterate();
                drawer.DrawGrid(DrawingData);
                if (gameLogic.IsEnd)
                    PlayerInputLoop.Stop();
            });
            gameLoop.Start();
            PlayerInputLoop.Run((direction) => gameLogic.CurrentSnakeDirection = direction);
            gameLoop.Stop();
            drawer.ResetConsoleWindow();
        }

        public void SetConsoleDrawer(IConsoleDrawerContainer container) {
            drawer = container.Create(gameLogic.Grid);
        }
    }
}

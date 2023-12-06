using System.Collections.Generic;
using System.Text;
using Keystroke.API;

namespace ConsoleSnakeMark2 {
    class GameProcessor {
        const int second = 1000;
        const int speedRatio = 100;

        static int SpeedToMs(int speed) {
            return second - Utility.VerifyValue(speed, GameData.MinSpeed, GameData.MaxSpeed) * speedRatio;
        }

        readonly GameLogic gameLogic;
        readonly int interval;
        IConsoleDrawer drawer;

        AdditionalDrawingData DrawingData => new AdditionalDrawingData(gameLogic.CurrentSnakeDirection, gameLogic.SnakeLenght, gameLogic.AteFood);

        GameProcessor(GameGrid grid, Snake snake, int speed) {
            gameLogic = new GameLogic(grid, snake);
            interval = SpeedToMs(speed);
            drawer = new ConsoleDrawer(gameLogic.Grid);
        }

        public GameProcessor(int gridHeight, int gridWidth, bool portalBorders, Point initialSnakePosition, int speed)
            : this(new GameGrid(gridHeight, gridWidth, portalBorders), new Snake(initialSnakePosition), speed) {
        }

        public GameProcessor(int gridHeight, int gridWidth, bool portalBorders, Point initialSnakePosition) : this(gridHeight, gridWidth, portalBorders, initialSnakePosition, GameData.DefaultSpeed) {
        }

        public GameProcessor(int gridHeight, int gridWidth, bool portalBorders) : this(gridHeight, gridWidth, portalBorders, GameData.DefaultSnakePosition(gridHeight, gridWidth)) {
        }

        public GameProcessor(int gridHeight, int gridWidth) : this(gridHeight, gridWidth, GameData.DefaultPortalBorders) {
        }

        public GameProcessor(ICustomGameGridData data) : this(new GameGrid(data.Height, data.Width, data.GridData), new Snake(data.InitialSnakePosition, data.InitialSnakeDirection), data.Speed) {
        }

        void ChangeDirection(Direction direction) {
            gameLogic.CurrentSnakeDirection = direction;
        }

        public void StartGameLoop() {
            using var keystroke = new KeystrokeAPI();
            keystroke.CreateKeyboardHook((character) => {
                switch (character.KeyCode) {
                    case KeyCode.Up:
                        ChangeDirection(Direction.Up);
                        break;
                    case KeyCode.Down:
                        ChangeDirection(Direction.Down);
                        break;
                    case KeyCode.Left:
                        ChangeDirection(Direction.Left);
                        break;
                    case KeyCode.Right:
                        ChangeDirection(Direction.Right);
                        break;
                    case KeyCode.Escape:
                        //Application.Exit();
                        break;
                }
            });
            drawer.SetConsoleWindow();
            drawer.DrawGrid(DrawingData);
            GameLoop gameLoop = new GameLoop(interval, () => {
                gameLogic.Iterate();
                drawer.DrawGrid(DrawingData);
                //if (gameLogic.IsEnd)
                //    Application.Exit();
            });
            //Application.Run();
            gameLoop.Stop();
            drawer.ResetConsoleWindow();
        }

        public void SetConsoleDrawer(IConsoleDrawerContainer container) {
            drawer = container.Create(gameLogic.Grid);
        }
    }
}

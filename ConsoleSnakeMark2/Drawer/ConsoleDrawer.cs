using System;

namespace ConsoleSnakeMark2 {
    public class ConsoleDrawer : IConsoleDrawer {
        readonly ConsoleWindowSizeHandler sizeHandler;
        readonly GameGrid grid;
        AdditionalDrawingData data;

        public ConsoleDrawer(GameGrid gameGrid) {
            sizeHandler = new ConsoleWindowSizeHandler(gameGrid.Height, gameGrid.Width);
            grid = gameGrid;
        }

        void DrawSymbol(char symbol) {
            Console.Write(symbol);
        }

        void DrawHead() {
            switch (data.SnakeHeadDirection) {
                case Direction.Up:
                    DrawSymbol(DrawerData.HeadUp);
                    break;
                case Direction.Down:
                    DrawSymbol(DrawerData.HeadDown);
                    break;
                case Direction.Left:
                    DrawSymbol(DrawerData.HeadLeft);
                    break;
                case Direction.Right:
                    DrawSymbol(DrawerData.HeadRight);
                    break;
            }
        }

        void DrawLine(int line) {
            for (int j = 0; j < grid.Width; j++) {
                ICell cell = grid[line, j];
                switch (cell.Type) {
                    case CellType.Empty:
                        DrawSymbol(DrawerData.Empty);
                        break;
                    case CellType.Border:
                        DrawSymbol(DrawerData.Border);
                        break;
                    case CellType.PortalBorder:
                        DrawSymbol(DrawerData.PortalBorder);
                        break;
                    case CellType.Food:
                        DrawSymbol(cell is SmallFoodCell ? DrawerData.SmallFood : DrawerData.BigFood);
                        break;
                    case CellType.SnakeHead:
                        DrawHead();
                        break;
                    case CellType.SnakeBody:
                        DrawSymbol(DrawerData.Body);
                        break;
                    case CellType.SnakeTailMoving:
                        DrawSymbol(DrawerData.MovingTail);
                        break;
                    case CellType.SnakeTailStatic:
                        DrawSymbol(DrawerData.StaticTail);
                        break;
                }
            }
        }

        public void DrawGrid(AdditionalDrawingData drawingData) {
            data = drawingData;
            int lastLine = grid.Height - 1;
            for (int i = 0; i < lastLine; i++) {
                DrawLine(i);
                Console.WriteLine();
            }
            DrawLine(lastLine);
            if (!Console.IsOutputRedirected)
                Console.SetCursorPosition(0, 0);
        }

        public void SetConsoleWindow() {
            sizeHandler.Set();
        }

        public void ResetConsoleWindow() {
            sizeHandler.Reset();
        }
    }
}
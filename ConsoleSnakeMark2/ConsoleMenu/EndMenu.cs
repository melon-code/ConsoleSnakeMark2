using System;
using ConsoleMenuAPI;

namespace ConsoleSnakeMark2 {
    public class EndMenu : StandardConsoleMenu {
        const int restartItemInd = 0;

        static void DrawLine(string line) {
            Console.WriteLine($"\t{line}\n");
        }

        readonly SnakeGameStats stats;

        public bool Restart => CurrentPosition == restartItemInd;

        public EndMenu(SnakeGameStats gameStats) : base(MenuItemListBuilder.EndMenu) {
            stats = gameStats;
        }

        protected override void Draw() {
            ConsoleMenuDrawer.SetCursorToLeftTopCorner();
            DrawLine(stats.IsWin ? SnakeGameLocalization.WinLine : SnakeGameLocalization.GameOverLine);
            DrawLine(string.Format(SnakeGameLocalization.DisplayLengthLine, stats.SnakeLength));
            DrawMenu();
        }
    }
}

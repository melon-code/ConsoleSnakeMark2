using System;

namespace ConsoleSnakeMark2 {
    public static class GameData {
        public const int MinConsoleHeight = 3;
        public const int MinConsoleWidth = 14;
        public const int MinGridHeight = 3;
        public const int MinGridWidth = 3;
        public const int MaxGridHeight = 500;
        public const int MaxGridWidth = 500;
        public const int MinSpeed = 1;
        public const int MaxSpeed = 10;
        public const int DefaultHeight = 15;
        public const int DefaultWidth = 15;
        public const int DefaultSpeed = 6;
        public const bool DefaultPortalBorders = false;
        public const bool ConsoleCursorVisibility = false;
        public const Direction DefaultSnakeDirection = Direction.Right;
        public const int SmallFoodValue = 1;

        public static int MaxConsoleHeight => Console.LargestWindowHeight;
        public static int MaxConsoleWidth => Console.LargestWindowWidth;

        public static Point DefaultSnakePosition(int gridHeight, int gridWidth) {
            return new Point(gridHeight / 2, gridWidth / 2);
        }
    }
}

using System;
using System.Collections.Generic;

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
        public const int BigFoodValue = 3;
        public const int BigFoodPeriod = 5;
        public const bool DefaultBigFood = false;

        public static int MaxConsoleHeight => Console.LargestWindowHeight;
        public static int MaxConsoleWidth => Console.LargestWindowWidth;
        public static IList<IGameLogicUser> DefaultAdditionalLogic => new List<IGameLogicUser>();

        public static Point DefaultSnakePosition(int gridHeight, int gridWidth) {
            return new Point(gridHeight / 2, gridWidth / 2);
        }
    }
}

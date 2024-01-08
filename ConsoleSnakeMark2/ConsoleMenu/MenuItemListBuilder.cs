using System.Collections.Generic;
using ConsoleMenuAPI;

namespace ConsoleSnakeMark2 {
    public static class MenuItemListBuilder {
        const int defaultGridType = 1, gridTypesCount = 3;
        const bool isCustomGrid = false;

        static readonly KeyStringToHash key = new KeyStringToHash();
        static readonly IntMenuItem CustomGrids = new IntMenuItem(key[SnakeGameLocalization.CustomGridTypeKey], defaultGridType, 1, gridTypesCount);

        public static IList<IMenuItem> MainMenu =>
             new List<IMenuItem>() { new ContinueItem(key[SnakeGameLocalization.NewGameKey]), new InsertedMenuItem(key[SnakeGameLocalization.SettingsKey], new SettingsMenu()), new ExitItem() };
        public static IList<IMenuItem> SettingsMenu => new List<IMenuItem>() {
                new IntMenuItem(key[SnakeGameLocalization.HeightKey], GameData.DefaultHeight, GameData.MinConsoleHeight, GameData.MaxConsoleHeight),
                new IntMenuItem(key[SnakeGameLocalization.WidthKey], GameData.DefaultWidth, GameData.MinConsoleWidth, GameData.MaxConsoleWidth),
                new BoolMenuItem(key[SnakeGameLocalization.PortalBorderKey], GameData.DefaultPortalBorders),
                new BoolMenuItem(key[SnakeGameLocalization.BigFoodKey], GameData.DefaultBigFood),
                new IntMenuItem(key[SnakeGameLocalization.SpeedKey], GameData.DefaultSpeed, GameData.MinSpeed, GameData.MaxSpeed),
                new DependencyBoolMenuItem(key[SnakeGameLocalization.CustomGridKey], isCustomGrid, new List<DependencyItem>() { new DependencyItem(CustomGrids) }), CustomGrids,
                new ExitItem(key[SnakeGameLocalization.SettingsExitKey])
            };
        public static IList<IMenuItem> EndMenu =>
            new List<IMenuItem>() { new ContinueItem(key[SnakeGameLocalization.RepeatKey]), new ContinueItem(key[SnakeGameLocalization.ToMainMenuKey]), new ExitItem() };

    }
}

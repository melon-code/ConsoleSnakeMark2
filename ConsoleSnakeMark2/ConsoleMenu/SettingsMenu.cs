using ConsoleMenuAPI;

namespace ConsoleSnakeMark2 {
    public class SettingsMenu : StandardConsoleMenu {
        const int heightInd = 0;
        const int widthInd = 1;
        const int portalBorderInd = 2;
        const int speedInd = 3;
        const int isCustomGridInd = 4;
        const int customGridTypeInd = 5;

        public GameSettings Settings => new GameSettings(GetInt(heightInd), GetInt(widthInd), GetBool(portalBorderInd), GetInt(speedInd), GetBool(isCustomGridInd), GetInt(customGridTypeInd));

        public SettingsMenu() : base(MenuItemListBuilder.SettingsMenu) {
        }
    }
}

using System;
using System.Text;
using ConsoleMenuAPI;

namespace ConsoleSnakeMark2 {
    public class MainMenu : ConsoleMenu {
        const int settingsMenuInd = 1;

        public GameSettings Settings => (GetInsertedMenu(settingsMenuInd) as SettingsMenu).Settings;

        public MainMenu() : base(MenuItemListBuilder.MainMenu) {
            SnakeGameLocalization.InitLocalization();
        }

        protected override void ProcessInput(ConsoleKey input) {
            if (input == ConsoleKey.Tab)
                SnakeGameLocalization.ChangeLanguage();
            ProcessInputByItem(input);
        }

        protected override void Draw() {
            base.Draw();
            Console.WriteLine($"\n\t{SnakeGameLocalization.ChangeLangLine} -> TAB   ");
        }
    }
}

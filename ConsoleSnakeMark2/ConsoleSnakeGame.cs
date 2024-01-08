using ConsoleMenuAPI;

namespace ConsoleSnakeMark2 {
    public static class ConsoleSnakeGame {
        const int typeAInd = 1, typeBInd = 2, typeCInd = 3;
        
        static ICustomGameGridData GetCustomGrid(int type) {
            switch (type) {
                case typeAInd:
                    return CustomGameGridTypes.TypeA;
                case typeBInd:
                    return CustomGameGridTypes.TypeB;
                default:
                    return CustomGameGridTypes.TypeC;
            }
        }
        
        public static void Play() {
            MenuEndResult endMenuResult = MenuEndResult.Further;
            MainMenu menu = new MainMenu();
            while (endMenuResult == MenuEndResult.Further && menu.ShowDialog() == MenuEndResult.Further) {
                bool restart;
                do {
                    GameSettings settings = menu.Settings;
                    GameProcessor processor = settings.CustomGrid ? new GameProcessor(GetCustomGrid(settings.CustomGridType)) :
                        new GameProcessor(settings.Height, settings.Width, settings.PortalBorders, settings.Speed, settings.BigFood);
                    processor.StartGameLoop();
                    EndMenu endMenu = new EndMenu(processor.GameStats);
                    endMenuResult = endMenu.ShowDialog();
                    restart = endMenu.Restart;
                } while (restart);
            }
        }
    }
}

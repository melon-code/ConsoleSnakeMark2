namespace ConsoleSnakeMark2 {
    public struct GameSettings {
        public int Height { get; }
        public int Width { get; }
        public bool PortalBorders { get; }
        public bool BigFood { get; }
        public int Speed { get; }
        public bool CustomGrid { get; }
        public int CustomGridType { get; }

        public GameSettings(int height, int width, bool portalBorders, bool bigFood, int speed, bool customGrid, int customGridType) {
            Height = height;
            Width = width;
            PortalBorders = portalBorders;
            BigFood = bigFood;
            Speed = speed;
            CustomGrid = customGrid;
            CustomGridType = customGridType;
        }
    }
}

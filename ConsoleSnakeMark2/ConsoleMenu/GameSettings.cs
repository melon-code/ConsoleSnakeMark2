namespace ConsoleSnakeMark2 {
    public struct GameSettings {
        public int Height { get; }
        public int Width { get; }
        public bool PortalBorders { get; }
        public int Speed { get; }
        public bool CustomGrid { get; }
        public int CustomGridType { get; }

        public GameSettings(int height, int width, bool portalBorders, int speed, bool customGrid, int customGridType) {
            Height = height;
            Width = width;
            PortalBorders = portalBorders;
            Speed = speed;
            CustomGrid = customGrid;
            CustomGridType = customGridType;
        }
    }
}

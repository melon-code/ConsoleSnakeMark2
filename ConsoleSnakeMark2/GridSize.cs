namespace ConsoleSnakeMark2 {
    public struct GridSize {
        public int Height { get; }
        public int Width { get; }

        public GridSize(int height, int width) {
            Height = Utility.VerifyValue(height, GameData.MinGridHeight, GameData.MaxGridHeight);
            Width = Utility.VerifyValue(width, GameData.MinGridWidth, GameData.MaxGridWidth);
        }

        public GridSize(int height, int width, int dataStringLenght) {
            if (height * width != dataStringLenght)
                throw GameExceptions.WrongGridDataSize;
            Height = height;
            Width = width;
        }
    }
}

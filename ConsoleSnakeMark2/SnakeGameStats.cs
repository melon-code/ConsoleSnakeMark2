namespace ConsoleSnakeMark2 {
    public struct SnakeGameStats {
        public bool IsWin { get; }
        public int SnakeLength { get; }
        public int AteFood { get; }

        public SnakeGameStats(bool isWin, int snakeLenght, int ateFood) {
            IsWin = isWin;
            SnakeLength = snakeLenght;
            AteFood = ateFood;
        }
    }
}

namespace ConsoleSnakeMark2 {
    public struct AdditionalDrawingData {
        public Direction SnakeHeadDirection { get; }
        public int SnakeLength { get; }
        public int AteFood { get; }

        public AdditionalDrawingData(Direction snakeHeadDirection, int snakeLength, int ateFood) {
            SnakeHeadDirection = snakeHeadDirection;
            SnakeLength = snakeLength;
            AteFood = ateFood;
        }
    }
}

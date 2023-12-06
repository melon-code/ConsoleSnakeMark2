namespace ConsoleSnakeMark2 {
    public struct CustomGameGridTypeA : ICustomGameGridData {
        public int Height => 10;
        public int Width => 12;
        public Point InitialSnakePosition => new Point(Height / 2, Width / 2);
        public Direction InitialSnakeDirection => Direction.Right;
        public int Speed => GameData.DefaultSpeed;
        public string GridData => "BBBBBBBBBBBB" +
                                  "B          B" +
                                  "B          B" +
                                  "B   BBBB   B" +
                                  "B          B" +
                                  "B          B" +
                                  "B   BBBB   B" +
                                  "B          B" +
                                  "B          B" +
                                  "BBBBBBBBBBBB";
    }
}

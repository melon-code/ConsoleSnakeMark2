namespace ConsoleSnakeMark2 {
    public struct CustomGameGridTypeB : ICustomGameGridData {
        public int Height => 4;

        public int Width => 10;

        public Point InitialSnakePosition => new Point(1,1);

        public Direction InitialSnakeDirection => Direction.Right;

        public int Speed => 8;

        public string GridData => "PPPPPPPPPP" +
                                  "P        P" +
                                  "P        p" +
                                  "PPPPPPPPPP";
    }
}

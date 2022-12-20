namespace ConsoleSnakeMark2 {
    public class Point {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) {
            X = x;
            Y = y;
        }

    }

    public class SnakePoint : Point {
        public SnakePoint(int x, int y) : base(x, y) {
        }

        public SnakePoint(Point point) : base(point.X, point.Y) {
        }

        public SnakePoint GetNextSnakePoint() {
            return null;
        }
    }
}

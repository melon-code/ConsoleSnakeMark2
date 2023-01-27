namespace ConsoleSnakeMark2 {
    public class SnakePoint : Point {
        public SnakePoint(int x, int y) : base(x, y) {
        }

        public SnakePoint(Point point) : base(point.X, point.Y) {
        }

        public SnakePoint GetNextSnakePoint(Direction direction) {
            int nextX = X, nextY = Y;
            switch (direction) {
                case Direction.Up:
                    nextX -= 1;
                    break;
                case Direction.Down:
                    nextX += 1;
                    break;
                case Direction.Left:
                    nextY -= 1;
                    break;
                case Direction.Right:
                    nextY += 1;
                    break;
            }
            return new SnakePoint(nextX, nextY);
        }
    }
}

using System;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleSnakeMark2 {
    public class Point : IEquatable<Point> {
        public static bool operator ==(Point point1, Point point2) {
            if (point1 == null || point2 == null)
                return false;
            return point1.X == point2.X && point1.Y == point2.Y;
        }

        public static bool operator !=(Point point1, Point point2) {
            return !(point1 == point2);
        }
        
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) {
            X = x;
            Y = y;
        }

        public override int GetHashCode() {
            return HashCode.Combine(X, Y);
        }

        public bool Equals([AllowNull] Point other) {
            return this == other;
        }

        public override bool Equals(object obj) {
            var point = obj as Point;
            if (point == null)
                return false;
            return this == point;
        }
    }

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

    public enum Direction {
        Up, Down, Left, Right
    }
}

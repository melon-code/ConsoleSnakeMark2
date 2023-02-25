using System;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleSnakeMark2 {
    public class Point : IEquatable<Point> {
        public static bool operator ==(Point point1, Point point2) {
            if (point1 is null && point2 is null)
                return true;
            if (point1 is null || point2 is null)
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
}

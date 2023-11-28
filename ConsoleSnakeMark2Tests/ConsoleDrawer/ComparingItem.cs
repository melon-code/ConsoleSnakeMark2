using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    public struct ComparingItem {
        public Point Point { get; }
        public char Char { get; }

        public ComparingItem(Point point, char symbol) {
            Point = point;
            Char = symbol;
        }

        public bool Compare(Point point, char symbol) {
            return Point == point && Char == symbol;
        }
    }
}

namespace ConsoleSnakeMark2 {
    public class SnakeFinder {
        bool isNoSnake;
        Point position;
        Direction direction = GameData.DefaultSnakeDirection;

        public Direction Direction => direction;

        public SnakeFinder() {
            isNoSnake = true;
        }

        bool TryGetDirection(char symbol, out Direction direction) {
            switch (symbol) {
                case ParsingData.SnakeUp:
                    direction = Direction.Up;
                    return true;
                case ParsingData.SnakeDown:
                    direction = Direction.Down;
                    return true;
                case ParsingData.SnakeRight:
                    direction = Direction.Right;
                    return true;
                case ParsingData.SnakeLeft:
                    direction = Direction.Left;
                    return true;
            }
            direction = GameData.DefaultSnakeDirection;
            return false;
        }

        public void TryFindSnake(string line, int lineNumber) {
            if (isNoSnake) {
                for (int i = 0; i < line.Length && isNoSnake; i++)
                    if (TryGetDirection(line[i], out direction)) {
                        isNoSnake = false;
                        position = new Point(lineNumber, i);
                    }
            }
        }

        public Point GetPosition(int height, int width) {
            return isNoSnake ? GameData.DefaultSnakePosition(height, width) : position;
        }
    }
}

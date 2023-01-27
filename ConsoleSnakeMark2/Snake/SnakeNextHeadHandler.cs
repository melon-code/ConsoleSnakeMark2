namespace ConsoleSnakeMark2 {
    public class SnakeNextHeadHandler {
        static bool IsOpposite(Direction direction1, Direction direction2) {
            switch (direction1) {
                case Direction.Up:
                    if (direction2 == Direction.Down)
                        return true;
                    break;
                case Direction.Down:
                    if (direction2 == Direction.Up)
                        return true;
                    break;
                case Direction.Left:
                    if (direction2 == Direction.Right)
                        return true;
                    break;
                case Direction.Right:
                    if (direction2 == Direction.Left)
                        return true;
                    break;
            }
            return false;
        }

        SnakeList snake;
        Point teleportedHead;
        bool isTeleported = false;
        Direction currentDirection = Direction.Right;

        public SnakeNextHeadHandler(SnakeList snakeList) {
            snake = snakeList;
        }

        public void SetNewHeadDirection(Direction direction) {
            if ((currentDirection != direction) && !IsOpposite(currentDirection, direction))
                currentDirection = direction;
        }

        public void SetTeleportedHead(Point head) {
            teleportedHead = head;
            isTeleported = true;
        }

        public SnakePoint GetNextHead() {
            if (isTeleported) {
                isTeleported = false;
                return new SnakePoint(teleportedHead);
            }
            return snake.Head.GetNextSnakePoint(currentDirection);
        }
    }
}

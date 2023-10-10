using System;

namespace ConsoleSnakeMark2 {
    public class SyncSnakeHandler {
        readonly Action<Point, ICell> setItemToGrid;
        Point currentSnakeHead;
        Point currentSnakeTail;

        public SyncSnakeHandler(Action<Point, ICell> setGridItem) {
            setItemToGrid = setGridItem;
        }

        void SetHeadToGrid(Point head) {
            setItemToGrid(head, new SnakeHeadCell());
        }

        void UpdateSnakeHead(Point newHead) {
            SetHeadToGrid(newHead);
            setItemToGrid(currentSnakeHead, new SnakeBodyCell());
            currentSnakeHead = newHead;
        }

        void UpdateSnakeTail(Point newTail) {
            setItemToGrid(currentSnakeTail, new EmptyCell());
            if (newTail != currentSnakeHead)
                setItemToGrid(newTail, new SnakeMovingTailCell());
            currentSnakeTail = newTail;
        }

        void UpdateSnakeTailState(bool movingNextTurn) {
            setItemToGrid(currentSnakeTail, CellFactory.CreateSnakeTail(movingNextTurn));
        }

        public void BoundSnake(Snake snake) {
            snake.HeadPositionChanged += new Snake.UpdateHeadPositionHandler((point) => UpdateSnakeHead(point));
            snake.TailPositionChanged += new Snake.UpdateTailPositionHandler((point) => UpdateSnakeTail(point));
            snake.TailStateChanged += new Snake.UpdateTailStateHandler((extending) => UpdateSnakeTailState(extending));
            currentSnakeTail = currentSnakeHead = snake.Head;
            SetHeadToGrid(currentSnakeHead);
        }
    }
}

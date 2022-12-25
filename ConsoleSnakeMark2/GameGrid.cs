using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeMark2 {
    public class GameGrid {
        readonly ICell[,] gameGrid;
        Point currentSnakeHead;
        Point currentSnakeTail;

        public GameGrid(int height, int width) {
            gameGrid = new ICell[height, width];
            //grid init
        }
        
        public ICell this[Point point] => gameGrid[point.X, point.Y];

        void SetItem(Point point, ICell item) {
            gameGrid[point.X, point.Y] = item;
        }

        public void UpdateSnakeHead(Point newHead) {
            SetItem(newHead, new SnakeHeadCell());
            SetItem(currentSnakeHead, new SnakeBodyCell());
            currentSnakeHead = newHead;
        }

        public void UpdateSnakeTail(Point newTail) {
            SetItem(currentSnakeTail, new EmptyCell());
            if (newTail != currentSnakeHead)
                SetItem(newTail, new MovingSnakeTailCell());
            currentSnakeTail = newTail;
        }

        public void UpdateSnakeTailState(bool extendingNextTurn) {
            SetItem(currentSnakeTail, extendingNextTurn ? new ExtendingSnakeTailCell() : new MovingSnakeTailCell());
        }

        public void AddFood(Point point, int foodValue) {
            SetItem(point, new FoodCell(foodValue));
        }
    }
}

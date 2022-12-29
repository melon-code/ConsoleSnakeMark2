using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleSnakeMark2 {
    public class GameGrid {
        readonly ICell[,] gameGrid;
        readonly HashSetIndexed emptyCells;
        Point currentSnakeHead;
        Point currentSnakeTail;

        public GameGrid(int height, int width) {
            gameGrid = new ICell[height, width];
            //grid init
            //add empty cells
        }

        public ICell this[Point point] => gameGrid[point.X, point.Y];

        void SetItem(Point point, ICell item) {
            gameGrid[point.X, point.Y] = item;
            emptyCells.Remove(point);
        }

        void ReleaseItem(Point point) {
            gameGrid[point.X, point.Y] = new EmptyCell();
            emptyCells.Add(point);
        }

        public void UpdateSnakeHead(Point newHead) {
            SetItem(newHead, new SnakeHeadCell());
            SetItem(currentSnakeHead, new SnakeBodyCell());
            currentSnakeHead = newHead;
        }

        public void UpdateSnakeTail(Point newTail) {
            ReleaseItem(currentSnakeTail);
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

    public class HashSetIndexed {
        readonly HashSet<Point> points;

        public Point this[int index] {
            get {
                var enumerator = points.GetEnumerator();
                for (int i = 0; i < index; i++) 
                    enumerator.MoveNext();
                return enumerator.Current;
            }
        }
        public int Count => points.Count;

        public HashSetIndexed() {
            points = new HashSet<Point>();
        }

        public bool Add(Point point) {
            return points.Add(point);
        }

        public bool Remove(Point point) {
            return points.Remove(point);
        }
    }
}

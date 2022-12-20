using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeMark2 {
    public class Snake {
        readonly LinkedList<SnakePoint> snake;
        int ateFood = 0;
        int leftFood = 0;

        SnakePoint HeadSnakePoint => snake.First.Value;
        Point Tail => snake.Last.Value;
        bool IsHungry => leftFood == 0;
        SnakePoint NewHead => HeadSnakePoint.GetNextSnakePoint();       
        public Point NextTurnHead => null;
        public int Length => snake.Count;
        public delegate void UpdateHeadPositionHandler(Point newHead);
        public event UpdateHeadPositionHandler UpdateHeadPosition;
        public delegate void UpdateTailPositionHandler(Point oldTail);
        public event UpdateTailPositionHandler UpdateTailPosition;

        public Snake(Point initialHead) {
            snake = new LinkedList<SnakePoint>();
            snake.AddFirst(new SnakePoint(initialHead));
        }

        public void Eat(int foodValue) {
            leftFood += foodValue;
            ateFood++;
        }

        public void Move() {
            var newHead = NewHead;
            UpdateHeadPosition(newHead);
            snake.AddFirst(newHead);
            if (IsHungry) {
                UpdateTailPosition(Tail);
                snake.RemoveLast();
            }
            else {
                leftFood--;
            }
        }
    }
}

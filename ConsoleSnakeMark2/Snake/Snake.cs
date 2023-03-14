using System;
using System.Text;

namespace ConsoleSnakeMark2 {
    public class Snake {
        readonly SnakeList snake;
        readonly SnakeNextHeadHandler headHandler;
        int ateFood = 0;
        int leftFood = 0;

        bool IsHungry => leftFood == 0;
        SnakePoint NewHead => headHandler.GetNextHead();
        public Point Head => snake.Head;
        public Point NextTurnHead => NewHead;
        public int Length => snake.Count;
        public delegate void UpdateHeadPositionHandler(Point newHead);
        public event UpdateHeadPositionHandler HeadPositionChanged;
        public delegate void UpdateTailPositionHandler(Point newTail);
        public event UpdateTailPositionHandler TailPositionChanged;
        public delegate void UpdateTailStateHandler(bool movingNextTurn);
        public event UpdateTailStateHandler TailStateChanged;

        public Snake(Point initialHead) {
            snake = new SnakeList(initialHead);
            headHandler = new SnakeNextHeadHandler(snake);
        }

        public void SetNewHeadDirection(Direction direction) {
            headHandler.SetNewHeadDirection(direction);
        }

        public void TeleportHead(Point destination) {
            headHandler.SetTeleportedHead(destination);
        }

        public void Eat(int foodValue) {
            leftFood += foodValue;
            ateFood++;
        }

        public void Move() {
            var newHead = NewHead;
            HeadPositionChanged(newHead);
            snake.AddHead(newHead);
            if (IsHungry) {
                snake.RemoveTail();
                TailPositionChanged(snake.Tail);
            }
            else {
                leftFood--;
                TailStateChanged(IsHungry);
            }
        }
    }
}

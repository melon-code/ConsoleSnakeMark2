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
        public Direction HeadDirection => headHandler.Direction;
        public Point NextTurnHead => NewHead;
        public int Length => snake.Count;
        public int AteFood => ateFood;
        public delegate void UpdateHeadPositionHandler(Point newHead);
        public event UpdateHeadPositionHandler HeadPositionChanged;
        public delegate void UpdateTailPositionHandler(Point newTail);
        public event UpdateTailPositionHandler TailPositionChanged;
        public delegate void UpdateTailStateHandler(bool movingNextTurn);
        public event UpdateTailStateHandler TailStateChanged;

        public Snake(Point initialHead, Direction initialDirection) {
            snake = new SnakeList(initialHead);
            headHandler = new SnakeNextHeadHandler(snake, initialDirection);
        }
        
        public Snake(Point initialHead) : this(initialHead, GameData.DefaultSnakeDirection) {
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
            HeadPositionChanged?.Invoke(newHead);
            snake.AddHead(newHead);
            if (IsHungry) {
                snake.RemoveTail();
                TailPositionChanged?.Invoke(snake.Tail);
            }
            else {
                leftFood--;
                TailStateChanged?.Invoke(IsHungry);
            }
        }
    }
}

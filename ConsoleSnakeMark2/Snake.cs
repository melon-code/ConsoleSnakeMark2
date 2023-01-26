using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeMark2 {
    public class Snake {
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

        readonly LinkedList<SnakePoint> snake;
        Direction currentDirection;
        int ateFood = 0;
        int leftFood = 0;

        SnakePoint Head { 
            get => snake.First.Value;
            set => snake.First.Value = value;
        }
        Point Tail => snake.Last.Value;
        bool IsHungry => leftFood == 0;
        SnakePoint NewHead => Head.GetNextSnakePoint(currentDirection);       
        public Point NextTurnHead => NewHead;
        public int Length => snake.Count;
        public delegate void UpdateHeadPositionHandler(Point newHead);
        public event UpdateHeadPositionHandler UpdateHeadPosition;
        public delegate void UpdateTailPositionHandler(Point newTail);
        public event UpdateTailPositionHandler UpdateTailPosition;
        public delegate void UpdateTailStateHandler(bool extendingNextTurn);
        public event UpdateTailStateHandler UpdateTailState;

        public Snake(Point initialHead) {
            snake = new LinkedList<SnakePoint>();
            snake.AddFirst(new SnakePoint(initialHead));
        }

        public void SetNewHeadDirection(Direction direction) {
            if ((currentDirection != direction) && !IsOpposite(currentDirection, direction))
                currentDirection = direction;
        }

        public void TeleportHead(Point destination) {
            Head = new SnakePoint(destination.X, destination.Y);
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
                snake.RemoveLast();
                UpdateTailPosition(Tail);
            }
            else {
                leftFood--;
                UpdateTailState(IsHungry);
            }
        }
    }
}

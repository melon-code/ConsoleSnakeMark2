using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeMark2 {
    public class GameLogic {
        const int smallFoodValue = 1;
        
        readonly Snake snake;
        readonly GameGrid grid;
        Direction currentSnakeDirection = Direction.Right;
        bool gameOver = false;

        bool IsWin => grid.Capacity == snake.Length;
        public bool IsEnd => IsWin || gameOver;
        public Direction CurrentSnakeDirection {
            get => currentSnakeDirection;
            set {
                if (value != currentSnakeDirection)
                    currentSnakeDirection = value;
            }
        }

        public GameLogic(GameGrid gameGrid, Snake snake) {
            grid = gameGrid;
            this.snake = snake;
            snake.UpdateHeadPosition += new Snake.UpdateHeadPositionHandler((point) => grid.UpdateSnakeHead(point));
            snake.UpdateTailPosition += new Snake.UpdateTailPositionHandler((point) => grid.UpdateSnakeTail(point));
            snake.UpdateTailState += new Snake.UpdateTailStateHandler((b) => grid.UpdateSnakeTailState(b));
        }

        public void StopGame() {
            gameOver = true;
        }

        public void MoveSnake() {
            snake.Move();
        }

        public void EatFood(int foodValue) {
            snake.Eat(foodValue);
        }

        public void SpawnFood() {
            grid.AddRandomFood(smallFoodValue);
        }

        public void Iterate() {
            if (!IsEnd) {
                snake.SetNewHeadDirection(currentSnakeDirection);
                CollisionBehaviorFactory factory = grid[snake.NextTurnHead].GetCollisionBehaviorFactory();
                factory.Create(this).Execute();
            }
        }
    }
}

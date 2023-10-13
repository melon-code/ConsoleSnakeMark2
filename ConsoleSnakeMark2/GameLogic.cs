using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeMark2 {
    public class GameLogic {
        public const int SmallFoodValue = 1;
        
        readonly Snake snake;
        readonly GameGrid grid;
        Direction currentSnakeDirection = Direction.Right;
        bool gameOver = false;

        bool IsWin => grid.Capacity == snake.Length;
        public GameGrid Grid => grid;
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
            grid.BoundSnake(snake);
            SpawnFood();
        }

        public void StopGame() {
            gameOver = true;
        }

        public void MoveSnake() {
            snake.Move();
        }

        public void TeleportSnake(Point headDestination) {
            snake.TeleportHead(headDestination);
        }

        public void EatFood(int foodValue) {
            snake.Eat(foodValue);
        }

        public void SpawnFood() {
            grid.AddFoodRandomPlace(SmallFoodValue);
        }

        public bool SpawnFood(Point point, int foodValue) {
            return grid.AddFood(point, foodValue);
        }

        public void ExecuteCollisionBehavior(Point collisionPoint) {
            ICollisionBehaviorParameters parameters = grid[collisionPoint].GetCollisionBehaviorParameters();
            parameters.CreateCollisionBehavior(this).Execute();
        }

        public void Iterate() {
            if (!IsEnd) {
                snake.SetNewHeadDirection(currentSnakeDirection);
                ExecuteCollisionBehavior(snake.NextTurnHead);
            }
        }
    }
}

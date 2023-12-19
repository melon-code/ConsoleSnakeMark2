using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeMark2 {
    public class GameLogic {
        readonly Snake snake;
        readonly GameGrid grid;
        Direction currentSnakeDirection;
        bool gameOver = false;

        public bool IsWin => grid.Capacity == snake.Length;
        public GameGrid Grid => grid;
        public int SnakeLength => snake.Length;
        public int AteFood => snake.AteFood;
        public bool IsEnd => IsWin || gameOver;
        public Direction CurrentSnakeDirection {
            get => snake.HeadDirection;
            set {
                if (value != currentSnakeDirection)
                    currentSnakeDirection = value;
            }
        }

        public GameLogic(GameGrid gameGrid, Snake initialSnake) {
            grid = gameGrid;
            snake = initialSnake;
            currentSnakeDirection = snake.HeadDirection;
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
            grid.AddFoodRandomPlace(GameData.SmallFoodValue);
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

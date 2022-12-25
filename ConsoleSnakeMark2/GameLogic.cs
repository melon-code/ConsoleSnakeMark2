using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeMark2 {
    public class GameLogic {
        readonly Snake snake;
        readonly GameGrid grid;
        Direction currentSnakeDirection = Direction.Right;

        public bool IsEnd => false;
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

        public void Iterate() {
            snake.SetNewHeadDirection(currentSnakeDirection);
            CollisionBehaviorFactory factory = grid[snake.NextTurnHead].GetCollisionBehaviorFactory();
            factory.Create(grid, snake).Execute();
        }
    }
}

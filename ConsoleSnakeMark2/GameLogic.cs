using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeMark2 {
    public class GameLogic {
        readonly Snake snake;
        readonly GameGrid grid;

        public bool IsEnd => false;

        public GameLogic(GameGrid gameGrid, Snake snake) {
            grid = gameGrid;
            this.snake = snake;
            snake.UpdateHeadPosition += new Snake.UpdateHeadPositionHandler((point) => grid.UpdateSnakeHead(point));
            snake.UpdateTailPosition += new Snake.UpdateTailPositionHandler((point) => grid.UpdateSnakeTail(point));
        }

        public void Iterate() {
            CollisionBehaviorFactory factory = grid[snake.NextTurnHead].GetCollisionBehaviorFactory();
            factory.Create(grid, snake).Execute();
        }
    }
}

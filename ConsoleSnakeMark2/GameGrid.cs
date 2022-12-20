using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeMark2 {
    public class GameGrid {
        readonly ICell[,] gameGrid;

        public GameGrid(int height, int width) {
            gameGrid = new ICell[height, width];
            //grid init
        }

        public ICell this[Point point] => gameGrid[point.X, point.Y];
        

        public void UpdateSnakeHead(Point newHead) {

        }

        public void UpdateSnakeTail(Point oldTail) {

        }
    }
}

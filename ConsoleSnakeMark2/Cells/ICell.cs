using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeMark2 {
    public interface ICell {
        CellType Type { get; }
        ICollisionBehaviorParameters GetCollisionBehaviorParameters();
    }

    public static class CellFactory {
        public static ICell CreateCell(CellType cellType) {
            switch (cellType) {
                case CellType.Empty:
                    return new EmptyCell();
                case CellType.Border:
                    return new BorderCell();
                case CellType.PortalBorder:
                    return null;
                case CellType.Food:
                    return new FoodCell(GameLogic.SmallFoodValue);
                case CellType.SnakeHead:
                    return new SnakeHeadCell();
                case CellType.SnakeBody:
                    return new SnakeBodyCell();
                case CellType.SnakeTailMoving:
                    return new SnakeMovingTailCell();
                case CellType.SnakeTailStatic:
                    return new SnakeStaticTailCell();
                default:
                    return new EmptyCell();
            }
        }

        public static ICell CreateSnakeTail(bool isExtending) {
            if (isExtending)
                return new SnakeStaticTailCell();
            return new SnakeMovingTailCell();
        }

        public static ICell CreateFood(int foodValue) {
            return new FoodCell(foodValue);
        }
    }
}

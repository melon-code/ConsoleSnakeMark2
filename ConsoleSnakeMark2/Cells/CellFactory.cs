namespace ConsoleSnakeMark2 {
    public static class CellFactory {
        public static ICell Border => new BorderCell();
        public static ICell Empty => new EmptyCell();
        public static ICell SmallFood => new FoodCell(GameData.SmallFoodValue);
        
        public static ICell CreateCell(CellType cellType) {
            switch (cellType) {
                case CellType.Empty:
                    return new EmptyCell();
                case CellType.Border:
                    return new BorderCell();
                case CellType.PortalBorder:
                    return null;
                case CellType.Food:
                    return new FoodCell(GameData.SmallFoodValue);
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

        public static ICell CreateSnakeTail(bool isMoving) {
            if (isMoving)
                return new SnakeMovingTailCell();
            return new SnakeStaticTailCell();
        }

        public static ICell CreateFood(int foodValue) {
            return new FoodCell(foodValue);
        }
    }
}

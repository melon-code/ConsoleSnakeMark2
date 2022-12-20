namespace ConsoleSnakeMark2 {
    public class FoodCell : ICell {
        readonly int value;

        public CellType Type => CellType.Food;

        public FoodCell(int foodValue) {
            value = foodValue;
        }

        public CollisionBehaviorFactory GetCollisionBehaviorFactory() {
            return new CollisionBehaviorFactory(value);
        }
    }
}

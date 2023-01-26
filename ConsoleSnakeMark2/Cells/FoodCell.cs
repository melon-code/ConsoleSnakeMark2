namespace ConsoleSnakeMark2 {
    public class FoodCell : ICell {
        readonly int value;

        public CellType Type => CellType.Food;

        public FoodCell(int foodValue) {
            value = foodValue;
        }

        public ICollisionBehaviorParameters GetCollisionBehaviorParameters() {
            return new FoodBehaviorParameters(value);
        }
    }
}

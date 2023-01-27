namespace ConsoleSnakeMark2 {
    public class FoodBehaviorParameters : SingleCollisionBehaviorParameter<int> {
        public FoodBehaviorParameters(int extendSnakeValue) : base(extendSnakeValue) {
        }

        public override ICollisionBehavior CreateCollisionBehavior(GameLogic gameLogic) {
            return new EatFoodBehavior(gameLogic, value);
        }
    }
}

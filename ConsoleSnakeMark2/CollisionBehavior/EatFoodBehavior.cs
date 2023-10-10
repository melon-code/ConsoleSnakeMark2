namespace ConsoleSnakeMark2 {
    public class EatFoodBehavior : CollisionBehaviorBase {
        readonly int value;
        
        public EatFoodBehavior(GameLogic gameLogic, int extendValue) : base(gameLogic) {
            value = extendValue;
        }
        
        public override void Execute() {
            logic.EatFood(value);
            logic.MoveSnake();
            if (!logic.IsEnd)
                logic.SpawnFood();
        }
    }
}

namespace ConsoleSnakeMark2 {
    public class MovingSnakeTail : ExtendingSnakeTail {
        public override CollisionBehaviorFactory GetCollisionBehaviorFactory() {
            return new CollisionBehaviorFactory(CollisionBehaviorType.Continue);
        }
    }
}

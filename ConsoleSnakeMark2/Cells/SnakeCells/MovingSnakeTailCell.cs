namespace ConsoleSnakeMark2 {
    public class MovingSnakeTailCell : ExtendingSnakeTailCell {
        public override CollisionBehaviorFactory GetCollisionBehaviorFactory() {
            return new CollisionBehaviorFactory(CollisionBehaviorType.Continue);
        }
    }
}

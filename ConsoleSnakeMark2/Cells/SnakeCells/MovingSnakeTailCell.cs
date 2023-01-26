namespace ConsoleSnakeMark2 {
    public class MovingSnakeTailCell : ExtendingSnakeTailCell {
        public override ICollisionBehaviorParameters GetCollisionBehaviorParameters() {
            return new CollisionBehaviorTypeParameter(CollisionBehaviorType.Continue);
        }
    }
}

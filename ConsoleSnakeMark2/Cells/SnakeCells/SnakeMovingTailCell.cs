namespace ConsoleSnakeMark2 {
    public class SnakeMovingTailCell : SnakeCell {
        public override CellType Type => CellType.SnakeTailMoving;

        public override ICollisionBehaviorParameters GetCollisionBehaviorParameters() {
            return new CollisionBehaviorTypeParameter(CollisionBehaviorType.Continue);
        }
    }
}

namespace ConsoleSnakeMark2 {
    public abstract class SnakeCell : ICell {
        public abstract CellType Type { get; }

        public virtual ICollisionBehaviorParameters GetCollisionBehaviorParameters() {
            return new CollisionBehaviorTypeParameter(CollisionBehaviorType.EndGame);
        }
    }
}

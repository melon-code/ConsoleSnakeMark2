namespace ConsoleSnakeMark2 {
    public abstract class SnakeCell : ICell {
        public abstract CellType Type { get; }

        public virtual CollisionBehaviorFactory GetCollisionBehaviorFactory() {
            return new CollisionBehaviorFactory(CollisionBehaviorType.EndGame);
        }
    }
}

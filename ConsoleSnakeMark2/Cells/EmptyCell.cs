namespace ConsoleSnakeMark2 {
    public class EmptyCell : ICell {
        public CellType Type => CellType.Empty;

        public CollisionBehaviorFactory GetCollisionBehaviorFactory() {
            return new CollisionBehaviorFactory(CollisionBehaviorType.Continue);
        }
    }
}

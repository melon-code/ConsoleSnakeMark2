namespace ConsoleSnakeMark2 {
    public class EmptyCell : ICell {
        public CellType Type => CellType.Empty;

        public ICollisionBehaviorParameters GetCollisionBehaviorParameters() {
            return new CollisionBehaviorTypeParameter(CollisionBehaviorType.Continue);
        }
    }
}

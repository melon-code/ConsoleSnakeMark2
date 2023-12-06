namespace ConsoleSnakeMark2 {
    public class BorderCell : ICell {
        public CellType Type => CellType.Border;

        public ICollisionBehaviorParameters GetCollisionBehaviorParameters() {
            return new CollisionBehaviorTypeParameter(CollisionBehaviorType.EndGame);
        }
    }
}

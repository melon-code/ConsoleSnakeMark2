namespace ConsoleSnakeMark2 {
    public class BorderCell : ICell {
        public CellType Type => CellType.Border;

        public CollisionBehaviorFactory GetCollisionBehaviorFactory() {
            return new CollisionBehaviorFactory(CollisionBehaviorType.EndGame);
        }
    }
}

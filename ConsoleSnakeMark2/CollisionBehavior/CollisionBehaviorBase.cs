namespace ConsoleSnakeMark2 {
    public abstract class CollisionBehaviorBase : ICollisionBehavior {
        protected readonly GameLogic logic;

        protected CollisionBehaviorBase(GameLogic gameLogic) {
            logic = gameLogic;
        }

        public abstract void Execute();
    }
}

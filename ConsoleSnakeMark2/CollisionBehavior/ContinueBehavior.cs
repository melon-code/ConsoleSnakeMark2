namespace ConsoleSnakeMark2 {
    public class ContinueBehavior : CollisionBehaviorBase {
        
        public ContinueBehavior(GameLogic gameLogic) : base(gameLogic) {
        }
        
        public override void Execute() {
            logic.MoveSnake();
        }
    }
}

namespace ConsoleSnakeMark2 {
    public class EndGameBehavior : CollisionBehaviorBase {
        public EndGameBehavior(GameLogic gameLogic) : base(gameLogic) {
        }
        
        public override void Execute() {
            logic.StopGame();
        }
    }
}

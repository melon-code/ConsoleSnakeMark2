namespace ConsoleSnakeMark2 {
    public class BaseSnakeTurn : GameLogicUser {
        public override void ApplyLogic() {
            if (!Logic.IsEnd) {
                Logic.SetCurrentDirection();
                Logic.ExecuteCollisionBehavior(Logic.NextTurn);
            }
        }
    }
}

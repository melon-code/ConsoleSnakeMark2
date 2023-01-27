namespace ConsoleSnakeMark2 {
    public class PortalBorderBehavior : CollisionBehaviorBase {
        readonly Point destination;

        public PortalBorderBehavior(GameLogic gameLogic, Point portalDestination) : base(gameLogic) {
            destination = portalDestination;
        }

        public override void Execute() {
            logic.TeleportSnake(destination);
            logic.ExecuteCollisionBehavior(destination);
        }
    }
}

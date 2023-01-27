namespace ConsoleSnakeMark2 {
    public class PortalBorderBehaviorParameters : SingleCollisionBehaviorParameter<Point> {
        public PortalBorderBehaviorParameters(Point portalDestination) : base(portalDestination) {
        }

        public override ICollisionBehavior CreateCollisionBehavior(GameLogic gameLogic) {
            return new PortalBorderBehavior(gameLogic, value);
        }
    }
}

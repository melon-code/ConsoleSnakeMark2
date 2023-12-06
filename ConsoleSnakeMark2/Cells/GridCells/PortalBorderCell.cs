namespace ConsoleSnakeMark2 {
    public class PortalBorderCell : ICell {
        readonly Point destination;

        public CellType Type => CellType.PortalBorder;

        public PortalBorderCell(Point portalDestination) {
            destination = portalDestination;
        }

        public ICollisionBehaviorParameters GetCollisionBehaviorParameters() {
            return new PortalBorderBehaviorParameters(destination);
        }
    }
}

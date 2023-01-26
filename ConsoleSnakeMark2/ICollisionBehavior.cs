namespace ConsoleSnakeMark2 {
    public interface ICollisionBehavior {
        void Execute();
    }

    public abstract class CollisionBehaviorBase : ICollisionBehavior {
        protected readonly GameLogic logic;

        protected CollisionBehaviorBase(GameLogic gameLogic) {
            logic = gameLogic;
        }

        public abstract void Execute();
    }

    public class ContinueBehavior : CollisionBehaviorBase {
        
        public ContinueBehavior(GameLogic gameLogic) : base(gameLogic) {
        }
        
        public override void Execute() {
            logic.MoveSnake();
        }
    }

    public class EndGameBehavior : CollisionBehaviorBase {
        public EndGameBehavior(GameLogic gameLogic) : base(gameLogic) {
        }
        
        public override void Execute() {
            logic.StopGame();
        }
    }

    public class EatFoodBehavior : CollisionBehaviorBase {
        readonly int value;
        
        public EatFoodBehavior(GameLogic gameLogic, int extendValue) : base(gameLogic) {
            value = extendValue;
        }
        
        public override void Execute() {
            logic.EatFood(value);
            logic.MoveSnake();
            logic.SpawnFood();
        }
    }

    public class PortalBorderBehavior : CollisionBehaviorBase {
        readonly Point destination;

        public PortalBorderBehavior(GameLogic gameLogic, Point portalDestination) : base(gameLogic) {
            destination = portalDestination;
        }

        public override void Execute() {
            logic.TeleportSnake(destination);
        }
    }

    public enum CollisionBehaviorType {
        Continue, EndGame
    }

    public interface ICollisionBehaviorParameters {
        ICollisionBehavior CreateCollisionBehavior(GameLogic gameLogic);
    }

    public class CollisionBehaviorTypeParameter : SingleCollisionBehaviorParameter<CollisionBehaviorType> {
        public CollisionBehaviorTypeParameter(CollisionBehaviorType behaviorType) : base(behaviorType) {
        }

        public override ICollisionBehavior CreateCollisionBehavior(GameLogic gameLogic) {
            switch (value) {
                case CollisionBehaviorType.Continue:
                    return new ContinueBehavior(gameLogic);
                case CollisionBehaviorType.EndGame:
                    return new EndGameBehavior(gameLogic);
                default:
                    return new ContinueBehavior(gameLogic);
            }
        }
    }

    public abstract class SingleCollisionBehaviorParameter<T> : ICollisionBehaviorParameters {
        protected readonly T value;

        public SingleCollisionBehaviorParameter(T parameter) {
            value = parameter;
        }

        public abstract ICollisionBehavior CreateCollisionBehavior(GameLogic gameLogic);
    }

    public class FoodBehaviorParameters : SingleCollisionBehaviorParameter<int> {
        public FoodBehaviorParameters(int extendSnakeValue) : base(extendSnakeValue) {
        }

        public override ICollisionBehavior CreateCollisionBehavior(GameLogic gameLogic) {
            return new EatFoodBehavior(gameLogic, value);
        }
    }

    public class PortalBorderBehaviorParameters : SingleCollisionBehaviorParameter<Point> {
        public PortalBorderBehaviorParameters(Point portalDestination) : base(portalDestination) {
        }

        public override ICollisionBehavior CreateCollisionBehavior(GameLogic gameLogic) {
            return new PortalBorderBehavior(gameLogic, value);
        }
    }
}

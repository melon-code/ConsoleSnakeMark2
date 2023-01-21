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

    public class ExtendSnakeBehavior : CollisionBehaviorBase {
        readonly int value;
        
        public ExtendSnakeBehavior(GameLogic gameLogic, int extendValue) : base(gameLogic) {
            value = extendValue;
        }
        
        public override void Execute() {
            logic.EatFood(value);
            logic.MoveSnake();
            logic.SpawnFood();
        }
    }

    public class CollisionBehaviorFactory {
        readonly CollisionBehaviorType type;
        readonly int extendValue;
        
        public CollisionBehaviorFactory(CollisionBehaviorType collisionType) {
            type = collisionType;
        }

        public CollisionBehaviorFactory(int extendSnakeValue) {
            type = CollisionBehaviorType.ExtendSnake;
            extendValue = extendSnakeValue;
        }

        public ICollisionBehavior Create(GameLogic gameLogic) {
            switch (type) {
                case CollisionBehaviorType.Continue:
                    return new ContinueBehavior(gameLogic);
                case CollisionBehaviorType.EndGame:
                    return new EndGameBehavior(gameLogic);
                case CollisionBehaviorType.ExtendSnake:
                    return new ExtendSnakeBehavior(gameLogic, extendValue);
                default:
                    return new ContinueBehavior(gameLogic);
            }
        }
    }

    public enum CollisionBehaviorType {
        Continue, EndGame, ExtendSnake
    }
}

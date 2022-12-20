namespace ConsoleSnakeMark2 {
    public interface ICollisionBehavior {
        void Execute();
    }

    public abstract class CollisionBehaviorBase : ICollisionBehavior {
        protected readonly GameGrid grid;
        protected readonly Snake snake;

        protected CollisionBehaviorBase(GameGrid gameGrid, Snake snake) {
            grid = gameGrid;
            this.snake = snake;
        }

        public abstract void Execute();
    }

    public class ContinueBehavior : CollisionBehaviorBase {
        
        public ContinueBehavior(GameGrid gameGrid, Snake snake) : base(gameGrid, snake) {
        }
        
        public override void Execute() {

        }
    }

    public class EndGameBehavior : CollisionBehaviorBase {
        public EndGameBehavior(GameGrid gameGrid, Snake snake) : base(gameGrid, snake) {
        }
        
        public override void Execute() {

        }
    }

    public class ExtendSnakeBehavior : CollisionBehaviorBase {
        readonly int value;
        
        public ExtendSnakeBehavior(GameGrid gameGrid, Snake snake, int extendValue) : base(gameGrid, snake) {
            value = extendValue;
        }
        
        public override void Execute() {

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

        public ICollisionBehavior Create(GameGrid gameGrid, Snake snake) {
            switch (type) {
                case CollisionBehaviorType.Continue:
                    return new ContinueBehavior(gameGrid, snake);
                case CollisionBehaviorType.EndGame:
                    return new EndGameBehavior(gameGrid, snake);
                case CollisionBehaviorType.ExtendSnake:
                    return new ExtendSnakeBehavior(gameGrid, snake, extendValue);
                default:
                    return new ContinueBehavior(gameGrid, snake);
            }
        }
    }

    public enum CollisionBehaviorType {
        Continue, EndGame, ExtendSnake
    }
}

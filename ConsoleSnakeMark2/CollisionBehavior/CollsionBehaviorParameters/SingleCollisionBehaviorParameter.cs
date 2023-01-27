namespace ConsoleSnakeMark2 {
    public abstract class SingleCollisionBehaviorParameter<T> : ICollisionBehaviorParameters {
        protected readonly T value;

        public SingleCollisionBehaviorParameter(T parameter) {
            value = parameter;
        }

        public abstract ICollisionBehavior CreateCollisionBehavior(GameLogic gameLogic);
    }
}

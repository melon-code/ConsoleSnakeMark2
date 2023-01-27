namespace ConsoleSnakeMark2 {
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
}

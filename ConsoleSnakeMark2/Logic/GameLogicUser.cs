namespace ConsoleSnakeMark2 {
    public abstract class GameLogicUser : IGameLogicUser {
        protected GameLogic Logic { get; private set; }

        public IGameLogicUser SetGameLogic(GameLogic logic) {
            Logic = logic;
            return this;
        }

        public abstract void ApplyLogic();
    }
}

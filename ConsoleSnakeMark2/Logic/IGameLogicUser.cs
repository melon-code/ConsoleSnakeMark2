namespace ConsoleSnakeMark2 {
    public interface IGameLogicUser {
        IGameLogicUser SetGameLogic(GameLogic logic);
        void ApplyLogic();
    }
}

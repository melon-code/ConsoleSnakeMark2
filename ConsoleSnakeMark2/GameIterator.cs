using System.Collections.Generic;

namespace ConsoleSnakeMark2 {
    public class GameIterator {
        readonly GameLogic logic;
        readonly IList<IGameLogicUser> users = new List<IGameLogicUser>();

        public GameIterator(GameLogic gameLogic, IList<IGameLogicUser> gameLogicUsers, bool addBaseSnakeTurn) {
            logic = gameLogic;
            if (addBaseSnakeTurn)
                AddUser(new BaseSnakeTurn());
            if (gameLogicUsers != null && gameLogicUsers.Count != 0)
                foreach (var user in gameLogicUsers)
                    AddUser(user);
        }

        public GameIterator(GameLogic logic, IList<IGameLogicUser> additionalGameLogicUsers) : this(logic, additionalGameLogicUsers, true) {
        }

        void AddUser(IGameLogicUser user) {
            users.Add(user.SetGameLogic(logic));
        }

        public void Iterate() {
            for (int i = 0; !logic.IsEnd && i < users.Count; i++)
                users[i].ApplyLogic();
        }
    }
}

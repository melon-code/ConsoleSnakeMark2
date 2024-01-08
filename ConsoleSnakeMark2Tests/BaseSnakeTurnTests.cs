using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class BaseSnakeTurnTests {
        const int size = 6;

        SnakePoint InitialHead => new SnakePoint(GameData.DefaultSnakePosition(size, size));

        [Test]
        public void ApplyLogicTest() {
            GameLogic logic = Helper.CreateGameLogic(size, size);
            IGameLogicUser snakeTurn = new BaseSnakeTurn().SetGameLogic(logic);
            snakeTurn.ApplyLogic();
            GameGrid grid = logic.Grid;
            Assert.IsInstanceOf<EmptyCell>(grid[InitialHead]);
            Assert.IsInstanceOf<SnakeHeadCell>(grid[InitialHead.GetNextSnakePoint(GameData.DefaultSnakeDirection)]);
        }
    }
}

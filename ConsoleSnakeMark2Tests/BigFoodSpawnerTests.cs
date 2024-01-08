using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class BigFoodSpawnerTests {
        class SmallFoodSpawner : GameLogicUser {
            int iterations = 2;

            Point DefaultPoint => GameData.DefaultSnakePosition(height, width);
            
            public override void ApplyLogic() {
                Logic.SpawnFood(new Point(DefaultPoint.X, DefaultPoint.Y + iterations), GameData.SmallFoodValue);
                iterations++;
            }
        }

        const int height = 6;
        const int width = 20;

        static bool TryFindBigFood(GameGrid grid) {
            for (int i = 0; i < grid.Height; i++)
                for (int j = 0; j < grid.Width; j++) {
                    ICell cell = grid[i, j];
                    if (cell is BigFoodCell) {
                        return true;
                    }
                }
            return false;
        }

        [Test]
        public void SpawnFoodTest() {
            GameLogic logic = Helper.CreateGameLogic(height, width);
            GameIterator iterator = new GameIterator(logic, new List<IGameLogicUser>() { new SmallFoodSpawner(), new BigFoodSpawner() });
            for (int i = 0; i < GameData.BigFoodPeriod; i++) {
                iterator.Iterate();
                Assert.IsFalse(TryFindBigFood(logic.Grid));
            }
            iterator.Iterate();
            Assert.IsTrue(TryFindBigFood(logic.Grid));
        }
    }
}

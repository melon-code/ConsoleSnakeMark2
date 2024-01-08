using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class GameIteratorTests {
        class TestLogicUser : GameLogicUser {
            public int Value { get; private set; } = 0;

            public override void ApplyLogic() {
                Value++;
            }
        }

        static IList<IGameLogicUser> GetList(GameIterator iterator) {
            const string usersListName = "users";
            return iterator.GetFieldValue<IList<IGameLogicUser>>(usersListName);
        }

        const int height = 8;
        const int width = 10;

        GameLogic Logic => Helper.CreateGameLogic(height, width);

        [Test]
        public void CreateIteratorTest() {
            const string logicName = "Logic";
            GameIterator iterator = new GameIterator(Logic, new List<IGameLogicUser>() { new BigFoodSpawner(), new TestLogicUser() });
            var list = GetList(iterator);
            Assert.IsInstanceOf<BaseSnakeTurn>(list[0]);
            Assert.IsInstanceOf<BigFoodSpawner>(list[1]);
            Assert.IsInstanceOf<TestLogicUser>(list[2]);
            for (int i = 0; i < list.Count; i++)
                Assert.IsNotNull(list[i].GetPropertyValue<GameLogic>(logicName));
        }

        [Test]
        public void IterateTest() {
            GameIterator iterator = new GameIterator(Logic, new List<IGameLogicUser>() { new TestLogicUser(), new TestLogicUser() }, false);
            iterator.Iterate();
            var list = GetList(iterator);
            for (int i = 0; i < list.Count; i++)
                Assert.AreEqual(1, (list[i] as TestLogicUser).Value);
        }
    }
}

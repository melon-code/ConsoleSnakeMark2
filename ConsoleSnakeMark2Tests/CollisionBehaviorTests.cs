using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSnakeMark2;
using NUnit.Framework;

namespace ConsoleSnakeMark2Tests {
    class CollisionBehaviorTests {
        //portal border beh
        const int gridSize = 10;

        static Point Center => new Point(gridSize / 2, gridSize / 2);

        static GameLogic CreateGameLogic(Point snakeHeadPosition) {
            return new GameLogic(new GameGrid(gridSize), new Snake(snakeHeadPosition));
        }

        [Test]
        public void ContinueBehaviorTest() {
            GameLogic logic = CreateGameLogic(Center);
            ContinueBehavior behavior = new ContinueBehavior(logic);
            behavior.Execute();
            GridTestHelper.AssertSnake<SnakeMovingTailCell>(logic.Grid, new Snake(new Point(Center.X, Center.Y + 1)));
            Assert.IsFalse(logic.IsEnd);
        }

        [Test]
        public void EndGameBehaviorTest() {
            GameLogic logic = CreateGameLogic(Center);
            EndGameBehavior behavior = new EndGameBehavior(logic);
            behavior.Execute();
            Assert.IsTrue(logic.IsEnd);
        }

        [Test]
        public void EatFoodBehaviorTest() {
            Point head = new Point(1, 1);
            GameLogic logic = new GameLogic(new GameGrid(3, 4), new Snake(head));
            EatFoodBehavior behavior = new EatFoodBehavior(logic, TestConst.SmallFoodValue);
            behavior.Execute();
            Snake expectedSnake = new Snake(head);
            expectedSnake.Eat(TestConst.SmallFoodValue);
            expectedSnake.Move();
            GridTestHelper.AssertSnake<SnakeMovingTailCell>(logic.Grid, expectedSnake);
            Assert.IsTrue(logic.IsEnd);
        }

        [Test]
        public void PortalBorderBehaviorTest() {
            GameLogic logic = CreateGameLogic(Center);
            GridTestHelper.TryFindFoodPoint(logic.Grid, out Point food);
            int y = food.Y + 1;
            Point destination = new Point(food.X, y == gridSize - 1 ? 1 : y);
            PortalBorderBehavior behavior = new PortalBorderBehavior(logic, destination);
            behavior.Execute();
            Snake expectedSnake = new Snake(Center);
            expectedSnake.TeleportHead(destination);
            expectedSnake.Move();
            GridTestHelper.AssertSnake<SnakeMovingTailCell>(logic.Grid, expectedSnake);
        }

        [Test]
        public void PortalBorderBehaviorFoodTest() {
            GameLogic logic = CreateGameLogic(Center);
            GridTestHelper.TryFindFoodPoint(logic.Grid, out Point food);
            PortalBorderBehavior behavior = new PortalBorderBehavior(logic, food);
            behavior.Execute();
            Snake expectedSnake = new Snake(Center);
            expectedSnake.TeleportHead(food);
            expectedSnake.Eat(TestConst.SmallFoodValue);
            expectedSnake.Move();
            GridTestHelper.AssertSnake<SnakeMovingTailCell>(logic.Grid, expectedSnake);
        }

        [Test]
        public void PortalBorderBehaviorGameOverTest() {
            GameLogic logic = CreateGameLogic(Center);
            PortalBorderBehavior behavior = new PortalBorderBehavior(logic, new Point(0,1));
            behavior.Execute();
            Assert.IsTrue(logic.IsEnd);
        }
    }
}

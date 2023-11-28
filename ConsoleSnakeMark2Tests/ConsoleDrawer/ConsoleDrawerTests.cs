using System;
using System.Text;
using System.IO;
using ConsoleSnakeMark2;
using NUnit.Framework;

namespace ConsoleSnakeMark2Tests {
    class ConsoleDrawerTests {
        const int height = GameLogicTestWrap.Height;
        const int width = GameLogicTestWrap.Width;

        static Point Center => GameLogicTestWrap.Center;

        static Point GetNextPoint(Direction direction, int steps = 1) {
            SnakePoint result = new SnakePoint(Center);
            for (int i = 0; i < steps; i++)
                result = result.GetNextSnakePoint(direction);
            return result;
        }

        static void PerformDrawerCheckBase(GameGrid grid, GridItemComparer comparer, AdditionalDrawingData data) {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            ConsoleDrawer drawer = new ConsoleDrawer(grid);
            drawer.DrawGrid(data);
            DrawerStringChecker.CheckData(writer.ToString().Split(writer.NewLine), grid.Height, grid.Width, comparer);
        }

        static void PerformDrawerCheck(GameGrid grid) {
            PerformDrawerCheckBase(grid, null, new AdditionalDrawingData());
        }

        static void PerformDrawerCheck(GameLogicTestWrap logic, Point head, Point body, Point tail, char headChar, char tailChar) {
            GridTestHelper.TryFindFoodPoint(logic.Grid, out Point food);
            PerformDrawerCheckBase(logic.Grid, new GridItemComparer(head, body, tail, headChar, tailChar, food), new AdditionalDrawingData(logic.CurrentDirection, 0, 0));
        }

        [Test]
        public void DrawGridTest() {
            PerformDrawerCheck(new GameGrid(height, width));
        }

        [TestCase(Direction.Up, DrawerData.HeadUp)]
        [TestCase(Direction.Down, DrawerData.HeadDown)]
        [TestCase(Direction.Left, DrawerData.HeadLeft)]
        [TestCase(Direction.Right, DrawerData.HeadRight)]
        public void DrawSnakeTest(Direction direction, char expectedHead) {
            int foodValue = 2;
            GameLogicTestWrap logic = new GameLogicTestWrap(direction);
            logic.EatFood(foodValue);
            logic.MoveSnakeWithoutCollision(direction);
            logic.MoveSnakeWithoutCollision(direction);
            PerformDrawerCheck(logic, GetNextPoint(direction, 2), GetNextPoint(direction), Center, expectedHead, DrawerData.MovingTail);
        }
    }
}

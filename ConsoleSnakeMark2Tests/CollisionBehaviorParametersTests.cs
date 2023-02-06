using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class CollisionBehaviorParametersTests {
        static ICollisionBehavior CreateCollisionBehavior(ICollisionBehaviorParameters parameters) {
            const int size = 6;
            return parameters.CreateCollisionBehavior(new GameLogic(new GameGrid(size, size), new Snake(new Point(size / 2, size / 2))));
        }
        
        static void CreateCollisionBehaviorTest(ICollisionBehaviorParameters parameters, Type expectedCollisionBehaviorType) {
            CreateCollisionBehaviorTest(CreateCollisionBehavior(parameters), expectedCollisionBehaviorType);
        }

        static void CreateCollisionBehaviorTest(ICollisionBehavior behavior, Type expectedCollisionBehaviorType) {
            Assert.IsInstanceOf(expectedCollisionBehaviorType, behavior);
        }

        static void CreateCollisionBehaviorValueTest<T>(ICollisionBehaviorParameters parameters, Type expectedCollisionBehaviorType, string valueName, T expectedValue) {
            var behavior = CreateCollisionBehavior(parameters);
            CreateCollisionBehaviorTest(behavior, expectedCollisionBehaviorType);
            Assert.AreEqual(expectedValue, behavior.GetFieldValue<T>(valueName));
        }

        [Test]
        public void CreateContinueBehaviorTest() {
            CreateCollisionBehaviorTest(new CollisionBehaviorTypeParameter(CollisionBehaviorType.Continue), typeof(ContinueBehavior));
        }

        [Test]
        public void CreateEndGameBehaviorTest() {
            CreateCollisionBehaviorTest(new CollisionBehaviorTypeParameter(CollisionBehaviorType.EndGame), typeof(EndGameBehavior));
        }

        [Test]
        public void CreateEatFoodBehaviorTest() {
            const string valueName = "value";
            const int foodValue = 1;
            CreateCollisionBehaviorValueTest(new FoodBehaviorParameters(foodValue), typeof(EatFoodBehavior), valueName, foodValue);
        }

        [Test]
        public void CreatePortalBorderBehaviorTest() {
            const int x = 3;
            const int y = 1;
            const string valueName = "destination";
            Point destination = new Point(x, y);
            CreateCollisionBehaviorValueTest(new PortalBorderBehaviorParameters(destination), typeof(PortalBorderBehavior), valueName, destination);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class SnakeTests {
        const int smallFood = 1;
        const int bigFood = 2;
        const int initialSnakeLength = 1;
        const string leftFoodName = "leftFood";
        const string ateFoodName = "ateFood";

        static SnakePoint InitialHead => new SnakePoint(4, 4);
        static SnakePoint MoveInitialHead => InitialHead.GetNextSnakePoint(TestConst.DefaultSnakeDirection);

        static Snake CreateSnake() {
            Snake snake = new Snake(InitialHead);
            snake.HeadPositionChanged += new Snake.UpdateHeadPositionHandler((head) => { });
            snake.TailPositionChanged += new Snake.UpdateTailPositionHandler((tail) => { });
            snake.TailStateChanged += new Snake.UpdateTailStateHandler((b) => { });
            return snake;
        }
        
        static Snake CreateSnakeAndEat() {
            Snake snake = CreateSnake();
            snake.Eat(smallFood);
            return snake;
        }

        static SnakeList GetSnakeList(Snake snake) {
            const string name = "snake";
            return snake.GetFieldValue<SnakeList>(name);
        }

        static void AssertEatFood(Snake snake, int expectedFoodValue, int expectedFoodCount) {
            Assert.AreEqual(expectedFoodValue, snake.GetFieldValue<int>(leftFoodName));
            Assert.AreEqual(expectedFoodCount, snake.GetFieldValue<int>(ateFoodName));
        }

        static void AssertHeadTail(Snake snake, int expectedLenght, Point expectedHead, Point expectedTail) {
            Assert.AreEqual(expectedLenght, snake.Length);
            Assert.AreEqual(expectedHead, GetSnakeList(snake).Head);
            Assert.AreEqual(expectedTail, GetSnakeList(snake).Tail);
        }

        [Test]
        public void EatFoodTest() {
            AssertEatFood(CreateSnakeAndEat(), smallFood, 1);
        }

        [Test]
        public void EatMultipleFood() {
            Snake snake = CreateSnakeAndEat();
            snake.Eat(bigFood);
            AssertEatFood(snake, smallFood + bigFood, 2);
        }

        [Test]
        public void MoveSnakeTest() {
            Snake snake = CreateSnake();
            snake.Move();
            AssertHeadTail(snake, initialSnakeLength, MoveInitialHead, MoveInitialHead);
        }

        [Test]
        public void EatAndMoveTest() {
            Snake snake = CreateSnakeAndEat();
            snake.Move();
            AssertHeadTail(snake, initialSnakeLength + 1, MoveInitialHead, InitialHead);
        }

        [Test]
        public void EatBigFoodAndMove() {
            Snake snake = CreateSnake();
            snake.Eat(bigFood);
            SnakePoint expectedHead = InitialHead;
            for (int i = 0; i < bigFood + 1; i++) {
                snake.Move();
                expectedHead = expectedHead.GetNextSnakePoint(TestConst.DefaultSnakeDirection);
            }
            AssertHeadTail(snake, initialSnakeLength + bigFood, expectedHead, MoveInitialHead);
        }
    }
}

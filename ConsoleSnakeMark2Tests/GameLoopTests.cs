using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ConsoleSnakeMark2Tests {
    class GameLoopTests {
        [Test]
        public void GameLoopIntervalTest() {
            const int range = 30, count = 5, interval = 200;
            GameLoopTestWrap gl = new GameLoopTestWrap(interval);
            for (int i = 0; i < count; i++) {
                gl.Start();
                do {
                } while (!gl.Stop);
                Assert.IsTrue(Math.Abs(gl.TimeBetweenMs - interval) < range);
            }
        }
    }
}
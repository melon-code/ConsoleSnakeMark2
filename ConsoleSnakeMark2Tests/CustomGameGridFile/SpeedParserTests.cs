using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class SpeedParserTests {
        [TestCase(4, "4")]
        [TestCase(15, "15")]
        [TestCase(GameData.DefaultSpeed, "14e")]
        [TestCase(GameData.DefaultSpeed, "2r3")]
        [TestCase(GameData.DefaultSpeed, "asdf")]
        public void GetSpeedTest(int expectedSpeed, string data) {
            Assert.AreEqual(expectedSpeed, SpeedParser.Get(data));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class UtilityTests {
        [TestCase(1, 0)]
        [TestCase(4, 4)]
        [TestCase(11, 15)]
        public void VerifyValueTest(int expected, int value) {
            const int min = 1;
            const int max = 11;
            Assert.AreEqual(expected, Utility.VerifyValue(value, min, max));
        }
    }
}

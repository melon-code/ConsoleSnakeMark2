using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class RandomPointGeneratorTests {
        [Test]
        public void GetPointTest() {
            const int pointCount = 10;
            HashSetIndexed set = new HashSetIndexed();
            for (int i = 0; i < pointCount; i++) 
                set.Add(new Point(i, i));
            var generator = new RandomPointGenerator(set);
            for (int i = 0; i < pointCount; i++) 
                set.Remove(generator.GetPoint());
            Assert.AreEqual(0, set.Count);
        }
    }
}

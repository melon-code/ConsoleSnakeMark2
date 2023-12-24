using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class GridSizeTests {
        const int height = 14, width = 12;

        [Test]
        public void ValidDataSizeTest() {
            GridSize size = new GridSize(height, width, height * width);
            Assert.AreEqual(height, size.Height);
            Assert.AreEqual(width, size.Width);
        }

        [Test]
        public void InvalidDataSizeTest() {
            Helper.AssertException(() => new GridSize(height, width, height), GameExceptions.WrongGridDataSize.Message);
        }
    }
}

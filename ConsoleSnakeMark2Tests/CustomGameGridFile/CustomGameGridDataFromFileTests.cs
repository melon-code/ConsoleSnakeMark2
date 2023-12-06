using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class CustomGameGridDataFromFileTests {

        [Test]
        public void NoFileTest() {
            const string path = @"\directory\file.txt";
            Assert.Throws<ArgumentException>(() => new CustomGameGridDataFromFile(path), GameExceptions.WrongFilePath.Message);
        }

        [Test]
        public void ParseFileTest() {
            const string path = @"CustomGameGridTestFile.txt";
            const string expectedData = "BBBBBB      B  D BB    BB    BBPPPPB";
            var data = new CustomGameGridDataFromFile(path);
            Assert.AreEqual(10, data.Speed);
            Assert.AreEqual(6, data.Height);
            Assert.AreEqual(6, data.Width);
            Assert.AreEqual(Direction.Down, data.InitialSnakeDirection);
            Assert.AreEqual(new Point(2, 3), data.InitialSnakePosition);
            Assert.AreEqual(expectedData, data.GridData);
        }
    }
}

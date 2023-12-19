using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class GridFileDataArrayTests {
        const string endLine = "\r\n";
        const string speedLine = "10" + endLine;

        [Test]
        public void GetValuesTest() {
            const string str1 = "BBBB", str2 = "B  B";
            const string data = speedLine + str1 + endLine + str2 + endLine + str1;
            GridFileDataArray array = new GridFileDataArray(data);
            Assert.AreEqual(3, array.Height);
            Assert.AreEqual(str1.Length, array.Width);
            Assert.AreEqual(new List<string>() { str1, str2, str1 }, array.GridLines);
        }

        [Test]
        public void EmptyFirstLineTest() {
            const string str = "BBBBB";
            const string data = speedLine + "" + endLine + str;
            GridFileDataArray array = new GridFileDataArray(data);
            Assert.AreEqual(2, array.Height);
            Assert.AreEqual(str.Length, array.Width);
        }

        [Test]
        public void NoGridDataTest() {
            const string empty = "" + endLine;
            const string data = speedLine + empty + empty;
            Helper.AssertException(() => new GridFileDataArray(data), GameExceptions.NoGridInFile.Message);
        }
    }
}

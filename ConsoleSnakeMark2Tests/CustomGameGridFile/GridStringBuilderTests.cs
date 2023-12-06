using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    class GridStringBuilderTests {
        [Test]
        public void AddEmptyLineTest() {
            const int width = 4;
            const string result = "    ";
            GridStringBuilder builder = new GridStringBuilder();
            builder.AddLine("", width);
            Assert.AreEqual(result, builder.GridData);
        }

        [Test]
        public void GetGridDataTest() {
            const int width = 3;
            const string str1 = "BBB", str2 = "   ", str3 = "B B";
            GridStringBuilder builder = new GridStringBuilder();
            builder.AddLine(str1, width);
            builder.AddLine(string.Empty, width);
            builder.AddLine(str3, width);
            Assert.AreEqual(str1 + str2 + str3, builder.GridData);
        }

        [Test]
        public void WrongWidthTest() {
            const int width = 4;
            GridStringBuilder builder = new GridStringBuilder();
            Assert.Throws<ArgumentException>(() => builder.AddLine("123", width), GameExceptions.NotEqualLenght.Message);
        }
    }
}

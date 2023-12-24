using System;
using System.IO;
using NUnit.Framework;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    public static class Helper {
        const string txtTag = ".txt";

        public static string GetFilePath(string folder, string fileName) {
            return Utility.GetPath(folder, fileName) + txtTag;
        }
        
        public static void AssertException(TestDelegate code, string expectedMessage) {
            Assert.AreEqual(expectedMessage, Assert.Throws<ArgumentException>(code).Message);
        }
    }
}
using ConsoleSnakeMark2;
using NUnit.Framework;

namespace ConsoleSnakeMark2Tests {
    public static class DrawerStringChecker {

        static void CheckLineLength(string line, int length) {
            Assert.AreEqual(length, line.Length);
        }

        static void CheckBorderItem(char item) {
            Assert.AreEqual(DrawerData.Border, item);
        }

        static void CheckBorderLine(string line, int width) {
            CheckLineLength(line, width);
            for (int i = 0; i < width; i++)
                CheckBorderItem(line[i]);
        }

        static void CheckFieldLine(string line, int width, int lineNumber, GridItemComparer comparer) {
            CheckLineLength(line, width);
            CheckBorderItem(line[0]);
            for (int i = 1; i < width - 1; i++)
                Assert.IsTrue(comparer.CompareItem(new Point(lineNumber, i), line[i]));
            CheckBorderItem(line[width - 1]);
        }

        public static void CheckData(string[] data, int height, int width, GridItemComparer comparer) {
            CheckBorderLine(data[0], width);
            for (int i = 1; i < height - 1; i++)
                CheckFieldLine(data[i], width, i, comparer ?? new GridItemComparer());
            CheckBorderLine(data[height - 1], width);
        }

        public static void CheckData(string[] data, int height, int width) {
            CheckData(data, height, width, null);
        }
    }
}

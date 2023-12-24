using System;
using System.IO;

namespace ConsoleSnakeMark2 {
    public static class Utility {
        public static int VerifyValue(int value, int min, int max) {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        public static string GetPath(string folder, string fileName) {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder, fileName);
        }
    }
}

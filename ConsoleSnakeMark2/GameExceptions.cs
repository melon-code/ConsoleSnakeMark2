using System;

namespace ConsoleSnakeMark2 {
    public static class GameExceptions {
        const string wrongGridDataSizeMessage = "Custom game grid data string has wrong lenght";
        const string wrongFilePathMessage = "CustomGrid data file does not exist";
        const string notEqualLenghMessage = "CustomGrid data file lines have not the same lenght";
        const string noGridInFileMessage = "CustomGrid data file has no grid lines";

        public static ArgumentException WrongGridDataSize => new ArgumentException(wrongGridDataSizeMessage);
        public static ArgumentException WrongFilePath => new ArgumentException(wrongFilePathMessage);
        public static ArgumentException NotEqualLenght => new ArgumentException(notEqualLenghMessage);
        public static ArgumentException NoGridInFile => new ArgumentException(noGridInFileMessage);
    }
}

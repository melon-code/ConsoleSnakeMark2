namespace ConsoleSnakeMark2 {
    public static class GameFiles {
        public const string Folder = "Data";
        public const string TypeCFileName = "CustomGridTypeC.txt";
        public const string LocalizationFileName = "Localization.xml";

        public static string TypeCFilePath => GetPath(TypeCFileName);
        public static string LocalizationFilePath => GetPath(LocalizationFileName);

        static string GetPath(string fileName) {
            return Utility.GetPath(Folder, fileName);
        }
    }
}

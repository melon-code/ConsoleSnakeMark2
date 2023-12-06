namespace ConsoleSnakeMark2 {
    public static class CustomGameGridTypes {
        const string typeCPath = @"CustomGridTypeC.txt";

        public static ICustomGameGridData TypeA => new CustomGameGridTypeA();
        public static ICustomGameGridData TypeB => new CustomGameGridTypeB();
        public static ICustomGameGridData TypeC => new CustomGameGridDataFromFile(typeCPath);
    }
}

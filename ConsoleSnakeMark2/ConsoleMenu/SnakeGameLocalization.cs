using ConsoleMenuAPI;

namespace ConsoleSnakeMark2 {
    public static class SnakeGameLocalization {
        const string rusDictionaryKey = "rus";
        const string engDictionaryKey = "eng";

        public const string NewGameKey = "ng";
        public const string SettingsKey = "settings";
        public const string ChangeLangKey = "changelang";

        public const string HeightKey = "height";
        public const string WidthKey = "width";
        public const string PortalBorderKey = "pb";
        public const string SpeedKey = "speed";
        public const string CustomGridKey = "iscg";
        public const string CustomGridTypeKey = "cgtypes";
        public const string SettingsExitKey = "setexit";

        public const string RepeatKey = "repeat";
        public const string ToMainMenuKey = "tomainmenu";
        public const string WinKey = "win";
        public const string GameOverKey = "gg";
        public const string DisplayLengthKey = "reslength";
        public const string DisplayFoodKey = "resfood";

        static readonly LocalizationDictionaryFromFile locFile = new LocalizationDictionaryFromFile(GameFiles.LocalizationFilePath, rusDictionaryKey);
        static readonly KeyStringToHash key = new KeyStringToHash();

        public static string ChangeLangLine => GetString(ChangeLangKey);
        public static string WinLine => GetString(WinKey);
        public static string GameOverLine => GetString(GameOverKey);
        public static string DisplayLengthLine => GetString(DisplayLengthKey);
        public static string DisplayFoodLine => GetString(DisplayFoodKey);

        static string GetString(string stringKey) {
            return Localization.GetString(key[stringKey]);
        }

        public static void InitLocalization() {
            Localization.ChangeLanguage(locFile);
        }

        public static void ChangeLanguage() {
            locFile.SetNewDictionary(locFile.CurrentDictionaryKey == rusDictionaryKey ? engDictionaryKey : rusDictionaryKey);
        }
    }
}

using System;

namespace ConsoleSnakeMark2 {
    public static class SpeedParser {
        const string numbers = "0123456789";
        
        static bool ValidateString(string str) {
            foreach (char symbol in str) {
                if (!numbers.Contains(symbol))
                    return false;
            }
            return true;
        }
        
        public static int Get(string line) {
            return ValidateString(line) ? Convert.ToInt32(line) : GameData.DefaultSpeed;
        }
    }
}

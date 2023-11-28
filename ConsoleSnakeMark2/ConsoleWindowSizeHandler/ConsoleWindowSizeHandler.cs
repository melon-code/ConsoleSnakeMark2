using System;

namespace ConsoleSnakeMark2 {
    public class ConsoleWindowSizeHandler {
        readonly ConsoleWindowState targetState;
        ConsoleWindowState initialState;
        bool pair = true;

        public ConsoleWindowSizeHandler(int consoleHeight, int consoleWidth) {
            int height = Utility.VerifyValue(consoleHeight, GameData.MinConsoleHeight, GameData.MaxConsoleHeight);
            int width = Utility.VerifyValue(consoleWidth, GameData.MinConsoleWidth, GameData.MaxConsoleWidth);
            targetState = new ConsoleWindowState(height, width, height, width + 1, GameData.ConsoleCursorVisibility);
        }
       
        void ChangeState(ConsoleWindowState state) {
            Console.Clear();
            Console.SetWindowSize(GameData.MinConsoleWidth, GameData.MinConsoleHeight);
            Console.SetBufferSize(state.BufferWidth, state.BufferHeight);
            Console.SetWindowSize(state.Width, state.Height);
            Console.CursorVisible = state.CursorVisibility;
        }

        public void Set() {
            if (pair) {
                initialState = ConsoleWindowState.GetCurrentState();
                ChangeState(targetState);
                pair = false;
            }
        }

        public void Reset() {
            if (!pair) {
                ChangeState(initialState);
                pair = true;
            }
        }
    }
}

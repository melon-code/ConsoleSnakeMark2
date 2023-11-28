using System;

namespace ConsoleSnakeMark2 {
    public struct ConsoleWindowState {
        public static ConsoleWindowState GetCurrentState() {
            return new ConsoleWindowState(Console.WindowHeight, Console.WindowWidth, Console.BufferHeight, Console.BufferWidth, Console.CursorVisible);
        }
        
        public int Height { get; }
        public int Width { get; }
        public int BufferHeight { get; }
        public int BufferWidth { get; }
        public bool CursorVisibility { get; }

        public ConsoleWindowState(int height, int width, int bufferHeight, int bufferWidth, bool cursorVisibility) {
            Height = height;
            Width = width;
            BufferHeight = bufferHeight;
            BufferWidth = bufferWidth;
            CursorVisibility = cursorVisibility;
        }
    }
}

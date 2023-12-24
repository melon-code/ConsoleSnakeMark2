using System;
using System.Threading;

namespace ConsoleSnakeMark2 {
    public static class PlayerInputLoop {
        const int waitInterval = 100;
        
        static readonly AutoResetEvent getInput = new AutoResetEvent(false);
        
        static bool IsStop { get; set; }

        public static void Run(Action<Direction> changeDirection) {
            while (!IsStop) {
                if (Console.KeyAvailable) {
                    switch (Console.ReadKey(true).Key) {
                        case ConsoleKey.UpArrow:
                            changeDirection(Direction.Up);
                            break;
                        case ConsoleKey.DownArrow:
                            changeDirection(Direction.Down);
                            break;
                        case ConsoleKey.LeftArrow:
                            changeDirection(Direction.Left);
                            break;
                        case ConsoleKey.RightArrow:
                            changeDirection(Direction.Right);
                            break;
                        case ConsoleKey.Escape:
                            Stop();
                            break;
                    }
                }
                else
                    getInput.WaitOne(waitInterval);
                
            }
        }

        public static void Stop() {
            IsStop = true;
            getInput.Set();
        }
    }
}

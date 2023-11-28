using System;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    public class GameLoopTestWrap {
        readonly GameLoop gameLoop;
        int count = 0;
        DateTime time, time1, time2;

        public int MilliSec1 => time1.Millisecond;
        public int MilliSec2 => time2.Millisecond;
        public int TimeBetweenMs => MilliSec1 > MilliSec2 ? 1000 - MilliSec1 + MilliSec2 : MilliSec2 - MilliSec1;
        public bool Stop => count > 1;

        public GameLoopTestWrap(int interval) {
            gameLoop = new GameLoop(interval, Iteration);
        }

        void Iteration() {
            time = DateTime.Now;
            if (count == 0) {
                time1 = time;
            }
            if (count == 1) {
                time2 = time;
                gameLoop.Stop();
            }
            count++;
        }

        public void Start() {
            count = 0;
            gameLoop.Start();
        }
    }
}
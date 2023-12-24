using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleSnakeMark2 {
    public class GameLoop {
        readonly Timer timer;

        public GameLoop(int timeBetweenIterations, Action iterationFunc) {
            timer = new Timer(timeBetweenIterations);
            //timer.Elapsed += async (s, e) => await Task.Run(iterationFunc);
            timer.Elapsed += (s, e) => iterationFunc();
        }

        public void Start() {
            timer.Start();
        }

        public void Stop() {
            timer.Stop();
        }
    }
}

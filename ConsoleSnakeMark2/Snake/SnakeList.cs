using System.Collections.Generic;

namespace ConsoleSnakeMark2 {
    public class SnakeList {
        readonly LinkedList<SnakePoint> snake;

        public SnakePoint Head => snake.First.Value;
        public SnakePoint Tail => snake.Last.Value;
        public int Count => snake.Count;

        public SnakeList(Point initialHead) {
            snake = new LinkedList<SnakePoint>(); ;
            AddHead(new SnakePoint(initialHead));
        }

        public void AddHead(SnakePoint newHead) {
            snake.AddFirst(newHead);
        }

        public void RemoveTail() {
            snake.RemoveLast();
        }
    }
}

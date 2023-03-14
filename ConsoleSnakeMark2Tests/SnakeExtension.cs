using System.Collections.Generic;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    public static class SnakeExtension {
        const string fieldName = "snake";
        const int onlyHeadLength = 1;
        const int onlyHeadTailLength = 2;

        static SnakeList GetSnakeList(this Snake snake) {
            return snake.GetFieldValue<SnakeList>(fieldName);
        }

        public static HashSet<Point> GetBody(this Snake snake) {
            if (snake.Length > onlyHeadTailLength) {
                var list = snake.GetSnakeList().GetFieldValue<LinkedList<SnakePoint>>(fieldName);
                int counter = 0;
                HashSet<Point> body = new HashSet<Point>();
                foreach (var item in list) {
                    if (counter > 0 && counter < list.Count - 1)
                        body.Add(item);
                    counter++;
                }
                return body;
            }
            return null;
        }

        public static Point GetTail(this Snake snake) {
            return snake.Length > onlyHeadLength ? snake.GetSnakeList().Tail : null;
        }
    }
}

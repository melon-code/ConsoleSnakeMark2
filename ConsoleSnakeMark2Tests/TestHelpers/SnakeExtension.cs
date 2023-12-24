using System.Collections.Generic;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    public static class SnakeExtension {
        const string fieldName = "snake";

        static SnakeList GetSnakeList(this Snake snake) {
            return snake.GetFieldValue<SnakeList>(fieldName);
        }

        public static HashSet<Point> GetBody(this Snake snake) {
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

        public static Point GetTail(this Snake snake) {
            return snake.GetSnakeList().Tail;
        }
    }
}

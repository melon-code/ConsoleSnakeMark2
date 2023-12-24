using System.Collections.Generic;

namespace ConsoleSnakeMark2 {
    public class HashSetIndexed {
        readonly HashSet<Point> points;

        public Point this[int index] {
            get {
                var enumerator = points.GetEnumerator();
                for (int i = -1; i < index; i++) 
                    enumerator.MoveNext();
                return enumerator.Current;
            }
        }
        public int Count => points.Count;

        public HashSetIndexed() {
            points = new HashSet<Point>();
        }

        public bool Add(Point point) {
            return points.Add(point);
        }

        public bool Remove(Point point) {
            return points.Remove(point);
        }
    }
}

using System;

namespace ConsoleSnakeMark2 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 1);
            Console.WriteLine(p1 == p2);
            SnakePoint sp1 = new SnakePoint(1, 1);
            SnakePoint sp2 = new SnakePoint(1, 2);
            Console.WriteLine(sp1 == sp2);
            Console.WriteLine(sp1.GetHashCode());
            Console.WriteLine(sp2.GetHashCode());

            HashPointTest();
        }

        public static void HashPointTest() {
            const int size = 10;
            System.Collections.Generic.HashSet<int> set = new System.Collections.Generic.HashSet<int>();
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                     if (!set.Add(new Point(i, j).GetHashCode())) {
                        Console.WriteLine(i.ToString() + ";" + j.ToString());
                    }
                }
            }
            set.GetHashCode();
        }
    }
}

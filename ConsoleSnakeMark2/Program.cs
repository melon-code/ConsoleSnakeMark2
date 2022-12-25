using System;

namespace ConsoleSnakeMark2 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 1);
            Console.WriteLine(p1 == p2);
            Console.Read();
        }
    }
}

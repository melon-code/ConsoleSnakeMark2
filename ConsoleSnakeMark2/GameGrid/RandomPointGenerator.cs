using System;

namespace ConsoleSnakeMark2 {
    public class RandomPointGenerator {
        readonly HashSetIndexed pointSet;
        readonly Random randomGenerator;

        public RandomPointGenerator(HashSetIndexed availablePoints) {
            pointSet = availablePoints;
            randomGenerator = new Random();
        }

        public Point GetPoint() {
            return pointSet[randomGenerator.Next(pointSet.Count)];
        }
    }
}

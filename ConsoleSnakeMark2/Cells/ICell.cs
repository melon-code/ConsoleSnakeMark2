using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeMark2 {
    public interface ICell {
        CellType Type { get; }
        CollisionBehaviorFactory GetCollisionBehaviorFactory();
    }

    public enum CellType {
        Empty, Border, Food, SnakeHead, SnakeBody, SnakeTail
    }

    public static class CellFactory {
        public static ICell CreateCell() {
            return null;
        }
    }
}

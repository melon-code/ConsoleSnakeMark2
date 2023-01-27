using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeMark2 {
    public interface ICell {
        CellType Type { get; }
        ICollisionBehaviorParameters GetCollisionBehaviorParameters();
    }

    public static class CellFactory {
        public static ICell CreateCell() {
            return null;
        }
    }
}

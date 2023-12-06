using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeMark2 {
    public interface ICell {
        CellType Type { get; }
        ICollisionBehaviorParameters GetCollisionBehaviorParameters();
    }
}

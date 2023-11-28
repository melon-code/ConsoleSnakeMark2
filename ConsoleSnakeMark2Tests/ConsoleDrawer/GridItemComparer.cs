using System.Collections.Generic;
using ConsoleSnakeMark2;

namespace ConsoleSnakeMark2Tests {
    public class GridItemComparer {
        readonly IList<ComparingItem> items = new List<ComparingItem>();

        public GridItemComparer() {
        }

        public GridItemComparer(Point snakeHead, Point snakeBody, Point snakeTail, char headChar, char tailChar, Point food) {
            AddItem(snakeHead, headChar);
            AddItem(snakeBody, DrawerData.Body);
            AddItem(snakeTail, tailChar);
            AddItem(food, DrawerData.Food);
        }

        void AddItem(Point point, char symbol) {
            if (point != null)
                items.Add(new ComparingItem(point, symbol));
        }

        public bool CompareItem(Point point, char item) {
            foreach (var element in items)
                if (element.Compare(point, item))
                    return true;
            return DrawerData.Empty == item;
        }
    }
}

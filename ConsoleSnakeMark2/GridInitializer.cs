using System;

namespace ConsoleSnakeMark2 {
    public static class GridInitializer {
        static int Positive(int number) {
            return number < 0 ? -number : number;
        }

        static int GetPortalDestination(int coordinate, int border) {
            return coordinate == 0 || coordinate == border ? Positive(coordinate - (border - 1)) : coordinate;
        }

        static ICell CreatePortalBorder(int indX, int indY, int height, int width) {
            return new PortalBorderCell(new Point(GetPortalDestination(indX, height - 1), GetPortalDestination(indY, width - 1)));
        }

        static bool IsBorder(int indX, int indY, int height, int width) {
            return indX == 0 || indY == 0 || indX == height - 1 || indY == width - 1;
        }

        static ICell ParseCell(int indX, int indY, string data, int height, int width) {
            switch (data[indX * width + indY]) {
                case ParsingData.Border:
                    return CellFactory.Border;
                case ParsingData.PortalBorder:
                    return CreatePortalBorder(indX, indY, height, width);
                case ParsingData.SmallFood:
                    return CellFactory.SmallFood;
            }
            if (IsBorder(indX, indY, height, width))
                return CellFactory.Border;
            return CellFactory.Empty;
        }

        static void IterateGrid(int height, int width, Action<Point, ICell> setCell, Func<int, int, ICell> getCell) {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    setCell(new Point(i, j), getCell(i, j));
        }

        public static ICell InitializeCell(int indX, int indY, bool portalBorders, int height, int width) {
            if (IsBorder(indX, indY, height, width)) {
                if (portalBorders)
                    return CreatePortalBorder(indX, indY, height, width);
                return CellFactory.Border;
            }
            return CellFactory.Empty;
        }

        public static void InitializeGrid(int height, int width, bool portalBorders, Action<Point, ICell> setCell) {
            IterateGrid(height, width, setCell, (x, y) => InitializeCell(x, y, portalBorders, height, width));
        }

        public static void ParseGrid(int height, int width, string data, Action<Point, ICell> setCell) {
            IterateGrid(height, width, setCell, (x, y) => ParseCell(x, y, data, height, width));
        }
    }
}

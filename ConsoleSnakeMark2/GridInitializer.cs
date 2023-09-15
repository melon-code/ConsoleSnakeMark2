using System;

namespace ConsoleSnakeMark2 {
    public static class GridInitializer {
        static int Positive(int number) {
            return number < 0 ? -number : number;
        }

        static int GetPortalDestination(int coordinate, int border) {
            return coordinate == 0 || coordinate == border ? Positive(coordinate - (border - 1)) : coordinate;
        }

        static ICell CreatePortalBorder(int indX, int indY, int rightBorder, int downBorder) {
            return new PortalBorderCell(new Point(GetPortalDestination(indX, downBorder), GetPortalDestination(indY, rightBorder)));
        }

        public static ICell InitializeCell(int indX, int indY, bool portalBorders, int height, int width) {
            int rightBorder = width - 1;
            int downBorder = height - 1;
            if (indX == 0 || indY == 0 || indX == downBorder || indY == rightBorder) {
                if (portalBorders)
                    return CreatePortalBorder(indX, indY, rightBorder, downBorder);
                return new BorderCell();
            }
            return new EmptyCell();
        }

        public static void InitializeGrid(int height, int width, bool portalBorders, Action<Point, ICell> setCell) {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    setCell(new Point(i, j), InitializeCell(i, j, portalBorders, height, width));
        }
    }
}

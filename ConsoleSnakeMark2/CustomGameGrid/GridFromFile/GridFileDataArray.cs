using System.Collections.Generic;

namespace ConsoleSnakeMark2 {
    public class GridFileDataArray {
        const string endLine = "\r\n";

        public string SpeedLine { get; }
        public int Height { get; }
        public int Width { get; } = -1;
        public IList<string> GridLines { get; }

        public GridFileDataArray(string data) {
            IList<string> lines = new List<string>(data.Split(endLine));
            SpeedLine = lines[ParsingData.SpeedLineIndex];
            lines.RemoveAt(ParsingData.SpeedLineIndex);
            GridLines = lines;
            Height = GridLines.Count;
            for (int i = 0; Width < 0 && i < Height; i++) {
                int width = GridLines[i].Length;
                if (width > 0)
                    Width = width;
            }
            if (Width < 0)
                throw GameExceptions.NoGridInFile;
        }
    }
}

using System.IO;

namespace ConsoleSnakeMark2 {
    public class CustomGameGridDataFromFile : ICustomGameGridData {
        public int Height { get; }
        public int Width { get; }
        public Point InitialSnakePosition { get; }
        public Direction InitialSnakeDirection { get; }
        public int Speed { get; }
        public string GridData { get; }

        public CustomGameGridDataFromFile(string filePath) {
            if (!File.Exists(filePath))
                throw GameExceptions.WrongFilePath;
            GridFileDataArray dataArray = new GridFileDataArray(File.ReadAllText(filePath));
            Speed = SpeedParser.Get(dataArray.SpeedLine);
            Height = dataArray.Height;
            Width = dataArray.Width;
            GridStringBuilder builder = new GridStringBuilder();
            SnakeFinder finder = new SnakeFinder();
            var gridLines = dataArray.GridLines;
            for (int i = 0; i < gridLines.Count; i++) {
                string line = gridLines[i];
                builder.AddLine(line, Width);
                finder.TryFindSnake(line, i);
            }
            InitialSnakePosition = finder.GetPosition(Height, Width);
            InitialSnakeDirection = finder.Direction;
            GridData = builder.GridData;
        }
    }
}

namespace ConsoleSnakeMark2 {
    public interface ICustomGameGridData {
        int Height { get; }
        int Width { get; }
        Point InitialSnakePosition { get; }
        Direction InitialSnakeDirection { get; }
        int Speed { get; }
        string GridData { get; }
    }
}

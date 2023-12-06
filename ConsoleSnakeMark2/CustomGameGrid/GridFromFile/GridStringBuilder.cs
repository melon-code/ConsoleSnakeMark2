using System.Text;

namespace ConsoleSnakeMark2 {
    public class GridStringBuilder {
        static string BuildEmptyString(int width) {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < width; i++)
                builder.Append(ParsingData.Empty);
            return builder.ToString();
        }

        readonly StringBuilder builder;

        public string GridData => builder.ToString();

        public GridStringBuilder() {
            builder = new StringBuilder();
        }

        public void AddLine(string line, int gridWidth) {
            string valid = string.IsNullOrEmpty(line) ? BuildEmptyString(gridWidth) : line;
            if (valid.Length != gridWidth)
                throw GameExceptions.NotEqualLenght;
            builder.Append(valid);
        }
    }
}


namespace UnityLike.Entities.Compiler
{
    public class ColoredToken
    {
        public string Value { get; }
        public int LineCount { get; }
        public int ColumnCount { get; }
        public string ColorCode { get; private set; }

        public ColoredToken(
            string value,
            int lineCount,
            int colmnCount,
            string colorCode = "FFFFFF"
            )
        {
            Value = value;
            LineCount = lineCount;
            ColumnCount = colmnCount;
            ColorCode = colorCode;
        }

        /// <summary>
        /// このトークンの色を変更します
        /// </summary>
        /// <param name="colorCode"></param>
        public void ChangeColor(string colorCode)
        {
            ColorCode = colorCode;
        }
    }
}
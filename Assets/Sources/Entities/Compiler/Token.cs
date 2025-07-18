
namespace UnityLike.Entities.Compiler
{
    public class Token
    {
        public TokenType TokenType { get; }
        public string Value { get; }
        public int LineCount { get; }
        public int ColumnCount { get; }

        public Token(
            TokenType tokenType,
            string value,
            int lineCount,
            int columnCount
            )
        {
            TokenType = tokenType;
            Value = value;
            LineCount = lineCount;
            ColumnCount = columnCount;
        }

        /// <summary>
        /// トークンの情報を文字列として取得します
        /// </summary>
        public override string ToString() // Token.ToString
        {
            string stringTokenType = TokenType.ToString(); // Enum.ToString
            string stringLineCount = LineCount.ToString(); // int.ToString
            string stringColumnCount = ColumnCount.ToString(); // int.ToString

            return $"[TokenType : {stringTokenType}, Value : {Value}, LineCount : {stringLineCount}, ColumnCount ; {stringColumnCount}]";
        }
    }
}
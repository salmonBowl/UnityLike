
namespace UnityLike.Entities.Compiler
{
    public class ColoredToken
    {
        public string Value { get; }
        public int LineCount { get; }
        public int ColumnCount { get; }
        public string ColorCode { get; private set; }
        public string ErrorMessage { get; private set; } = string.Empty;

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

        /// <summary>
        /// このトークンがエラーである時、メッセージとともに色を赤に変更します
        /// </summary>
        /// <param name="errorMessage"></param>
        public void HasError(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ChangeColor(TokenConstants.errorColor);
        }

        /// <summary>
        /// このトークンがメンバー変数である時、色をメンバー変数のものに変更します
        /// </summary>
        public void IsMember()
        {
            ColorCode = TokenConstants.syntaxHighlightColors[TokenType.Member];
        }

        /// <summary>
        /// トークンの情報を文字列として取得します
        /// </summary>
        public override string ToString() // Token.ToString
        {
            string stringLineCount = LineCount.ToString(); // int.ToString
            string stringColumnCount = ColumnCount.ToString(); // int.ToString

            return $"[Value : {Value}, LineCount : {stringLineCount}, ColumnCount : {stringColumnCount}, ColorCode : {ColorCode}]";
        }
    }
}
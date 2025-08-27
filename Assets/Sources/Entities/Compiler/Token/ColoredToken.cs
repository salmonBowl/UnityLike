
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
    }
}
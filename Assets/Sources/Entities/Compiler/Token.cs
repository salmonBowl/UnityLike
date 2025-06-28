
namespace UnityLike.Entities.Compiler
{
    public class Token
    {
        public TokenType TokenType { get; private set; }
        public string Value { get; private set; }
        public int Line { get; private set; }
        public int Column { get; private set; }

        public Token(
            TokenType tokenType,
            string value,
            int line,
            int column
            )
        {
            TokenType = tokenType;
            Value = value;
            Line = line;
            Column = column;
        }
    }
}
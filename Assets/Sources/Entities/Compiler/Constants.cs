using System.Collections.Generic;

namespace UnityLike.Entities.Compiler
{
    public class Constants
    {
        public static readonly char[] whiteSpaceChars =
        {
            ' ',
            '\t',
            //'\n', :\nは改行トークンとして処理されるようになりました
            //'\r' // 最初に\r\nを\nに置換したので出てくることはありません
        };

        // テキストエディタ―で改行した時に表示される文字です
        // 現在は\nを表示されています
        public static string returnText = "\\n";

        public static readonly Dictionary<string, TokenType> twoCharOperators = new()
        {
            { "==", TokenType.EqualEquals },
            { "!=", TokenType.NotEquals },
            { "+=", TokenType.PlusEquals },
            { "-=", TokenType.MinusEquals },
            { "*=", TokenType.MultiplyEquals },
            { "/=", TokenType.DivideEquals },
            { "++", TokenType.Increment },
            { "--", TokenType.Decrement },
            { ">=", TokenType.GreaterThanOrEqual },
            { "<=", TokenType.LessThanOrEqual }
        };
        public static readonly Dictionary<char, TokenType> oneCharOperators = new()
        {
            { '+', TokenType.Plus },
            { '-', TokenType.Minus },
            { '*', TokenType.Multiply },
            { '/', TokenType.Divide },
            { '=', TokenType.Equals },
            { '!', TokenType.Unknown }, // '!'単体はUnknownですが、2文字で != になる可能性があります
            { '>', TokenType.GreaterThan },
            { '<', TokenType.LessThan }
        };


        private static readonly string operatorColor = "#FFFFFF";
        public static readonly Dictionary<TokenType, string> syntaxHighlightColors = new()
        {
            { TokenType.Identifier, "#86DEFE" },

            #region 演算子
            { TokenType.NumberLiteral, operatorColor },
            { TokenType.Plus, operatorColor },
            { TokenType.Minus, operatorColor },
            { TokenType.Multiply, operatorColor },
            { TokenType.Divide, operatorColor },
            { TokenType.Equals, operatorColor },
            { TokenType.PlusEquals,     operatorColor },
            { TokenType.MinusEquals, operatorColor },
            { TokenType.MultiplyEquals, operatorColor },
            { TokenType.DivideEquals, operatorColor },
            { TokenType.Increment, operatorColor },
            { TokenType.Decrement, operatorColor },
            { TokenType.EqualEquals, operatorColor },
            { TokenType.NotEquals, operatorColor },
            { TokenType.GreaterThan, operatorColor },
            { TokenType.GreaterThanOrEqual, operatorColor },
            { TokenType.LessThan, operatorColor },
            { TokenType.LessThanOrEqual, operatorColor },
            #endregion

            // エラーを赤色に
            { TokenType.Unknown, "#FF0000" },

            #region キーワード (制御構文や型名など)
            #endregion

            { TokenType.Return, "#00FF00" },
        };
    }
}

using System.Collections.Generic;

namespace UnityLike.Entities.Compiler
{
    public class Constants
    {
        public static readonly char[] whiteSpaceChars =
        {
            ' ',
            '\t',
            //'\n', :\n�͉��s�g�[�N���Ƃ��ď��������悤�ɂȂ�܂���
            //'\r' // �ŏ���\r\n��\n�ɒu�������̂ŏo�Ă��邱�Ƃ͂���܂���
        };

        // �e�L�X�g�G�f�B�^�\�ŉ��s�������ɕ\������镶���ł�
        // ���݂�\n��\������Ă��܂�
        // string�^�Ƃ���[\\n]���ۑ�����A���ꂪ�����TMP���[\n]�ƕ\������܂�
        public static string returnText = "\\\\n";

        #region ������TokenType ��dictionary

        public static readonly Dictionary<string, TokenType> TwoCharOperators = new()
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
        public static readonly Dictionary<char, TokenType> OneCharOperators = new()
        {
            { '+', TokenType.Plus },
            { '-', TokenType.Minus },
            { '*', TokenType.Multiply },
            { '/', TokenType.Divide },
            { '=', TokenType.Equals },
            { '!', TokenType.Unknown }, // '!'�P�̂�Unknown�ł����A2������ != �ɂȂ�\��������܂�
            { '>', TokenType.GreaterThan },
            { '<', TokenType.LessThan },

            { '.', TokenType.Dot },
            { ',', TokenType.Comma },
            { ';', TokenType.SemiColon },

            { '(', TokenType.LeftParen },
            { ')', TokenType.RightParen },
            { '{', TokenType.LeftBrace },
            { '}', TokenType.RightBrace },
            { '[', TokenType.LeftBracket },
            { ']', TokenType.RightBracket }
        };
        public static readonly Dictionary<string, TokenType> KeyWords = new()
        {
            { "if", TokenType.If },
            { "else", TokenType.Else },
            { "for", TokenType.For },
            { "while", TokenType.While },

            { "int", TokenType.TypeStandard },
            { "float", TokenType.TypeStandard },
            { "bool", TokenType.TypeStandard },
            { "string", TokenType.TypeStandard },

            { "new", TokenType.New },
            { "null", TokenType.Null },
            { "true", TokenType.True },
            { "false", TokenType.False },
            { "public", TokenType.Public },
            { "private", TokenType.Private }
        };

        #endregion

        private static readonly string operatorColor = "#FFFFFF";
        private static readonly string controlSyntaxColor = "#FF00FF";
        public static readonly Dictionary<TokenType, string> syntaxHighlightColors = new()
        {
            { TokenType.Identifier, "#86DEFE" },

            #region ���Z�q�A�������Ȃ�
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

            { TokenType.Dot, operatorColor },
            { TokenType.Comma, operatorColor },

            { TokenType.LeftParen, operatorColor },
            { TokenType.RightParen, operatorColor },
            { TokenType.LeftBrace, operatorColor },
            { TokenType.RightBrace, operatorColor },
            { TokenType.LeftBracket, operatorColor },
            { TokenType.RightBracket, operatorColor },
            #endregion

            { TokenType.SemiColon, "#FFFFFF" },

            // �G���[��ԐF��
            { TokenType.Unknown, "#FF0000" },

            #region �L�[���[�h (����\����^���Ȃ�)
            { TokenType.If, controlSyntaxColor },
            { TokenType.Else, controlSyntaxColor },
            { TokenType.For, controlSyntaxColor },
            { TokenType.While, controlSyntaxColor },
            { TokenType.TypeStandard, "#0000FF" },
            { TokenType.New, "#0000FF" },
            { TokenType.Null, "#0000FF" },
            { TokenType.True, "#0000FF" },
            { TokenType.False, "#0000FF" },
            { TokenType.Public, "#0000FF" },
            { TokenType.Private, "#0000FF" },
            #endregion

            { TokenType.Return, "#00FF00" },
        };
    }
}

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
            { '!', TokenType.Unknown }, // '!'�P�̂�Unknown�ł����A2������ != �ɂȂ�\��������܂�
            { '>', TokenType.GreaterThan },
            { '<', TokenType.LessThan }
        };


        private static readonly string operatorColor = "#FFFFFF";
        public static readonly Dictionary<TokenType, string> syntaxHighlightColors = new()
        {
            { TokenType.Identifier, "#86DEFE" },

            #region ���Z�q
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

            // �G���[��ԐF��
            { TokenType.Unknown, "#FF0000" },

            #region �L�[���[�h (����\����^���Ȃ�)
            #endregion

            { TokenType.Return, "#00FF00" },
        };
    }
}

using System.Collections.Generic;

namespace UnityLike.Entities.Compiler
{
    public class TokenConstants
    {
        public static readonly char[] whiteSpaceChars =
        {
            ' ',
            '\t',
            //'\n', :\nは改行トークンとして処理されるようになりました
            //'\r' // 最初に\r\nを\nに置換したので出てくることはありません
        };
        public static readonly char[] number =
        {
            '0','1','2','3','4','5','6','7','8','9',
            '.', 'f'
        };

        // テキストエディタ―で改行した時に表示される文字です
        // 現在は\nを表示されています
        // string型として[\\n]が保存され、これがさらにTMP上で[\n]と表示されます
        //public static string returnText = "\\\\n";
        public static string returnText = "";

        #region 文字→TokenType のdictionary

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
            { '!', TokenType.Unknown }, // '!'単体はUnknownですが、2文字で != になる可能性があります
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
            { ']', TokenType.RightBracket },

            { '\\', TokenType.BackSlash },
        };
        public static readonly Dictionary<string, TokenType> KeyWords = new()
        {
            { "if", TokenType.If },
            { "else", TokenType.Else },
            { "for", TokenType.For },
            { "while", TokenType.While },

            { "new", TokenType.New },
            { "null", TokenType.Null },
            { "true", TokenType.True },
            { "false", TokenType.False },

            { "int", TokenType.TypePrimitive },
            { "float", TokenType.TypePrimitive },
            { "bool", TokenType.TypePrimitive },
            { "string", TokenType.TypePrimitive },

            { "Object", TokenType.TypeOther },
            { "GameObject", TokenType.TypeOther },
            { "Component", TokenType.TypeOther },
            { "Transform", TokenType.TypeOther },
            { "RectTransform", TokenType.TypeOther },
            { "Rigidbody", TokenType.TypeOther },
            { "Rigidbody2D", TokenType.TypeOther },
            { "Collider", TokenType.TypeOther },
            { "BoxCollider", TokenType.TypeOther },
            { "SphereCollider", TokenType.TypeOther },
            { "CapsuleCollider", TokenType.TypeOther },
            { "Vector2", TokenType.TypeOther },
            { "Vector3", TokenType.TypeOther },
            { "Vector4", TokenType.TypeOther },
            { "Quaternion", TokenType.TypeOther },
            { "Mathf", TokenType.TypeOther },
            { "Time", TokenType.TypeOther },
            { "Random", TokenType.TypeOther },
            { "Input", TokenType.TypeOther },
            { "Renderer", TokenType.TypeOther },
            { "MeshRenderer", TokenType.TypeOther },
            { "SkinnedMeshRenderer", TokenType.TypeOther },
            { "Material", TokenType.TypeOther },
            { "Color", TokenType.TypeOther },
            { "MonoBehaviour", TokenType.TypeOther },
            { "SceneManager", TokenType.TypeOther },
            { "Animetor", TokenType.TypeOther },
            { "Canvas", TokenType.TypeOther },
            { "Text", TokenType.TypeOther },
            { "Image", TokenType.TypeOther },
            { "Debug", TokenType.TypeOther },
        };

        #endregion

        public static readonly string errorColor = "#FF0000";
        private static readonly string operatorColor = "#FFFFFF";
        private static readonly string controlSyntaxColor = "#D846FF";
        private static readonly string constBlue = "#569CD6";
        public static readonly Dictionary<TokenType, string> syntaxHighlightColors = new()
        {
            { TokenType.Identifier, "#86DEFE" },
            { TokenType.Member, "#FFFFFF" },

            #region 演算子、かっこなど
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

            // エラーを赤色に
            { TokenType.Unknown, errorColor },
            { TokenType.BackSlash, errorColor },

            #region キーワード (制御構文や型名など)
            { TokenType.If, controlSyntaxColor },
            { TokenType.Else, controlSyntaxColor },
            { TokenType.For, controlSyntaxColor },
            { TokenType.While, controlSyntaxColor },
            { TokenType.New, constBlue },
            { TokenType.Null, constBlue },
            { TokenType.True, constBlue },
            { TokenType.False, constBlue },
            #endregion
            
            { TokenType.TypePrimitive, constBlue },
            { TokenType.TypeOther, "#00FFAE" },

            { TokenType.Return, "#00FF00" },
        };
    }
}

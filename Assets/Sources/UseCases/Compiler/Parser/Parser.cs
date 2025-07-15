using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    /// <summary>
    /// 構文解析をします
    /// 受け取ったトークン列から構文列へ変換し、その際に不明な書式があれば検出します
    /// </summary>
    /*
        public:
            void Parse();
     */
    public class Parser
    {
        private readonly Token[] tokenArray;
        private int currentTokenIndex;

        private Token CurrentToken => tokenArray[currentTokenIndex];
        private TokenType CurrentTokenType => CurrentToken.TokenType;

        public Parser(Token[] tokenArray)
        {
            this.tokenArray = tokenArray;
            currentTokenIndex = 0;
        }

        #region 補助メソッド
        /// <summary>
        /// 構文解析処理を行うメソッドです
        /// </summary>
        public void Parse()
        {

        }

        ExpressionNode ConsumeWithGenerate()
        {
            currentTokenIndex++;

            if (tokenArray.Length <= currentTokenIndex)
                throw new System.IndexOutOfRangeException("Parser : 範囲外のConsumeが行われました");

            return CurrentTokenType switch
            {
                TokenType.Identifier => new IdentifierNode(CurrentToken.Value),
                TokenType.NumberLiteral => new NumberLiteralNode(int.Parse(CurrentToken.Value)),
                _ => null,
            };
        }

        /// <summary>
        /// UnknownNodeを返します
        /// </summary>
        /// <returns></returns>
        private UnknownNode AsUnknown()
        {
            return new UnknownNode(CurrentToken.Value);
        }

        /// <summary>
        /// トークンを先読みします
        /// </summary>
        /// <param name="offset">どれだけ先を読むのか指定します。0だとcurrentToken</param>
        private Token Peek(int offset)
        {
            int returnTokenIndex = currentTokenIndex + offset;
            if (tokenArray.Length < returnTokenIndex)
            {
                throw new System.IndexOutOfRangeException("配列外のトークンを参照しようとしています");
            }
            
            return tokenArray[returnTokenIndex];
        }
        #endregion

        #region AST

        // 構文木を再帰的な関数呼び出しにより構成していきます

        /// <summary>
        /// 再帰呼び出しの開始地点
        /// currentTokenから先がどんな構文になっているのかを再帰的に解析していきます
        /// </summary>
        private ExpressionNode ParseExpression()
        {
            // 最も優先順位の低い演算子を呼び出します

            return ;
        }

        /// <summary>
        /// 再帰呼び出しの終端地点
        /// リテラルや識別子など、currentTokenに対する構文木の構成がここで決定されます
        /// </summary>
        private ExpressionNode ParsePrimaryExpression()
        {
            return CurrentTokenType switch
            {
                TokenType.Identifier => ConsumeWithGenerate(),
                TokenType.NumberLiteral => ConsumeWithGenerate(),
                TokenType.LeftParen => ParseParenExpression(),
                _ => AsUnknown()
            };
        }

        private ExpressionNode ParseParenExpression()
        {
            if (CurrentTokenType == TokenType.LeftParen)
                ConsumeWithGenerate();
            else
                return AsUnknown();

            ExpressionNode content = ParseExpression();

            if (CurrentTokenType == TokenType.RightParen)
                ConsumeWithGenerate();
            else
                return AsUnknown();

            return content;
        }
        #endregion
    }
}

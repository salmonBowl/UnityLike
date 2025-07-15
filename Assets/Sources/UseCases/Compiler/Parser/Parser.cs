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

        /// <summary>
        /// 構文解析処理を行うメソッドです
        /// </summary>
        public void Parse()
        {

        }

        #region 補助メソッド

        void Consume()
        {
            currentTokenIndex++;

            if (tokenArray.Length <= currentTokenIndex)
                throw new System.IndexOutOfRangeException("Parser : 範囲外のConsumeが行われました");
        }
        ExpressionNode ConsumeWithGenerate()
        {
            ExpressionNode retval = CurrentTokenType switch
            {
                TokenType.Identifier => new IdentifierNode(CurrentToken.Value),
                TokenType.NumberLiteral => new NumberLiteralNode(int.Parse(CurrentToken.Value)),
                _ => null,
            };

            Consume();

            return retval;
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
        /*
         *  例 : 5 * (1 + 1)
         *      
         *      ParseStartExpression();
         *      ...
         *      ParseAdditiveExpression();
         *      ParseMultipleExpression(); → BinaryExpressionNode(leftExpression, *, ParseStartExpression()) を生成
         *      leftExpression = ParseUnaryExpression();
         *      ParsePrimaryExpression(); → NumberLiteralNode(5) を生成
         *      
         *      ParseStartExpression();
         *      ParseParenExpression(); → ParenNode(content) を生成
         *      content = ParseStartExpression();
         *      ...
         *      ParseAdditiveExpression(); → BynaryExpressionNode(leftExpression, + , ParseStartExpression()) を生成
         *      leftExpression = ParseUnaryExpression();
         *      ParsePrimaryExpression() → NumberLiteralNode(1) を生成
         *      
         *      ParseStartExpression();
         *      ...
         *      ParsePrimaryExpression(); → NumberLiteral(1) を生成
         *      
         *      ↓
         *      
         *      Bynary(Number(5), *, Paren(Binary(Number(1), + ,Number(1)))) という形の構文木が、
         *      最初のParseStartExpressionの戻り値として返される
         */

        /// <summary>
        /// 再帰呼び出しの開始地点
        /// currentTokenから先がどんな構文になっているのかを再帰的に解析していきます
        /// </summary>
        private ExpressionNode ParseStartExpression()
        {
            // 最も優先順位の低い演算子を呼び出します

            return ParseAdditiveExpression();
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
                Consume();
            else
                return AsUnknown();

            ExpressionNode content = ParseStartExpression();

            if (CurrentTokenType == TokenType.RightParen)
                Consume();
            else
                return AsUnknown();

            return new ParenNode(content);
        }
        private ExpressionNode ParseUnaryExpression()
        {
            if (CurrentTokenType == TokenType.Minus)
            {
                Consume();
                return new UnaryExpressionNode(TokenType.Minus, ParsePrimaryExpression());
            }
            else
            {
                return ParsePrimaryExpression();
            }
        }
        private ExpressionNode ParseMultitiveExpression()
        {
            ExpressionNode leftExpression = ParseUnaryExpression();

            if (CurrentTokenType == TokenType.Multiply)
            {
                Consume();
                return new BinaryExpressionNode(leftExpression, TokenType.Multiply, ParseStartExpression());
            }
            else if (CurrentTokenType == TokenType.Divide)
            {
                Consume();
                return new BinaryExpressionNode(leftExpression, TokenType.Divide, ParseStartExpression());
            }
            else
            {
                return leftExpression;
            }
        }
        private ExpressionNode ParseAdditiveExpression()
        {
            ExpressionNode leftExpression = ParseMultitiveExpression();

            if (CurrentTokenType == TokenType.Plus)
            {
                Consume();
                return new BinaryExpressionNode(leftExpression, TokenType.Plus, ParseStartExpression());
            }
            else if (CurrentTokenType == TokenType.Minus)
            {
                Consume();
                return new BinaryExpressionNode(leftExpression, TokenType.Minus, ParsePrimaryExpression());
            }
            else
            {
                return leftExpression;
            }
        }

        #endregion
    }
}

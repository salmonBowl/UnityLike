using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    partial class Parser
    {
        /// <summary>
        /// UnknownExpressionNodeを返します
        /// </summary>
        /// <returns></returns>
        private UnknownExpressionNode AsUnknown()
        {
            return new UnknownExpressionNode(CurrentToken.Value);
        }

        // 構文木を再帰的な関数呼び出しにより構成していきます
        // エントリポイント : ParseExpression();
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

        /*
            識別子システムを未実装
            TokenType.TypeStandardで仮置きしています
         */

        /// <summary>
        /// 再帰呼び出しの開始地点
        /// currentTokenから先がどんな構文になっているのかを再帰的に解析していきます
        /// </summary>
        private ExpressionNode ParseExpression()
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

            ExpressionNode content = ParseExpression();

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
                return new BinaryExpressionNode(leftExpression, TokenType.Multiply, ParseExpression());
            }
            else if (CurrentTokenType == TokenType.Divide)
            {
                Consume();
                return new BinaryExpressionNode(leftExpression, TokenType.Divide, ParseExpression());
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
                return new BinaryExpressionNode(leftExpression, TokenType.Plus, ParseExpression());
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
    }
}
using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    public partial class Parser
    {
        /// <summary>
        /// UnknownExpressionNodeを返します
        /// </summary>
        /// <returns></returns>
        private UnknownExpressionNode AsUnknown()
        {
            return ASTFactory.UnknownNode(CurrentToken);
        }
        private UnknownExpressionNode AsUnknown(string message)
        {
            return ASTFactory.UnknownNode(CurrentToken, message);
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

            return ParseComparisonExpression();
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
                TokenType.StringLiteral => ConsumeWithGenerate(),
                TokenType.True => ConsumeWithGenerate(),
                TokenType.False => ConsumeWithGenerate(),
                TokenType.LeftParen => ParseParenExpression(),
                TokenType.New => ParseNewExpression(),
                TokenType.TypePrimitive => ParseStaticMemberAccess(),
                TokenType.TypeOther => ParseStaticMemberAccess(),
                TokenType.Unknown => AsUnknown(),
                TokenType.SemiColon => throw new SyntaxErrorException("文が完成していません"),
                TokenType.RightParen => throw new SyntaxErrorException("値がありません"),
                _ => throw new SyntaxErrorException("文法が正しくありません")
            };
        }

        private ExpressionNode ParseParenExpression()
        {
            Usecase u = new(this);

            ColoredToken leftParen =
                u.LeftParen();
            ExpressionNode content =
                u.Expression();
            ColoredToken rightParen =
                u.RightParen();

            return new ParenNode(leftParen, content, rightParen);
        }
        /*
            演算の優先順位に従って優先順位が低い演算→だんだん高い演算という順序で再帰的に潜っていきます
            
            Comparison → Addtive → Multitive → Unary → MemberAccess → Primary
         */
        private ExpressionNode ParseMemberAccessExpression()
        {
            Usecase u = new(this);

            // 最初の要素を解析
            ExpressionNode primary = ParsePrimaryExpression();

            // ここで左辺が変数であることを確認
            if (primary is not VariableNode left)
            {
                return primary;
            }

            while (CurrentTokenType == TokenType.Dot)
            {
                ColoredToken dot =
                    u.Dot();
                ColoredToken member =
                    u.Member();

                if (CurrentTokenType == TokenType.LeftParen)
                {
                    // メンバー関数として処理

                    ColoredToken leftParen =
                        u.LeftParen();

                    var arguments = ParseArgumentList(out var commas);

                    ColoredToken rightParen =
                        u.RightParen();

                    return ASTFactory.MemberFunctionNode
                        (left, dot, member, leftParen, arguments, commas, rightParen);
                }
                else
                {
                    // メンバー変数として処理
                    left = ASTFactory.MemberAccessNode(left, dot, member);
                }
            }

            return left;
        }
        private ExpressionNode ParseUnaryExpression()
        {
            if (CurrentTokenType is TokenType.Minus or TokenType.Not)
            {
                Token @operator = CurrentToken;
                Consume();
                return ASTFactory.UnaryExpressionNode(@operator, ParseMemberAccessExpression());
            }
            else
            {
                return ParseMemberAccessExpression();
            }
        }
        private ExpressionNode ParseMultitiveExpression()
        {
            ExpressionNode leftExpression = ParseUnaryExpression();

            if (CurrentTokenType == TokenType.Multiply || CurrentTokenType == TokenType.Divide)
            {
                Token @operator = CurrentToken;
                Consume();
                return ASTFactory.BinaryExpressionNode(leftExpression, @operator, ParseMultitiveExpression());
            }
            else
            {
                return leftExpression;
            }
        }
        private ExpressionNode ParseAdditiveExpression()
        {
            ExpressionNode leftExpression = ParseMultitiveExpression();

            if (CurrentTokenType == TokenType.Plus || CurrentTokenType == TokenType.Minus)
            {
                Token @operator = CurrentToken;
                Consume();
                return ASTFactory.BinaryExpressionNode(leftExpression, @operator, ParseAdditiveExpression());
            }
            else
            {
                return leftExpression;
            }
        }
        private ExpressionNode ParseComparisonExpression()
        {
            ExpressionNode leftExpression = ParseAdditiveExpression();

            if (CurrentTokenType is
                TokenType.GreaterThan or
                TokenType.GreaterThanOrEqual or
                TokenType.LessThan or
                TokenType.LessThanOrEqual or
                TokenType.EqualEquals or
                TokenType.NotEquals)
            {
                Token @operator = CurrentToken;
                Consume();
                return ASTFactory.BinaryExpressionNode(leftExpression, @operator, ParseAdditiveExpression());
            }
            else
            {
                return leftExpression;
            }
        }
        private MemberFunctionNode ParseStaticMemberAccess()
        {
            Usecase u = new(this);

            TypeNode @class =
                u.Type();
            ColoredToken dot =
                u.Dot();
            ColoredToken member =
                u.Member();
            ColoredToken leftParen =
                u.LeftParen();

            var arguments = ParseArgumentList(out var commas);

            ColoredToken rightParen =
                u.RightParen();

            return ASTFactory.MemberFunctionNode
                (@class, dot, member, leftParen, arguments, commas, rightParen);
        }
    }
}

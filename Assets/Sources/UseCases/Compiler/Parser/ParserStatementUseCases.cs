using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    public partial class Parser
    {
        private class Usecase
        {
            readonly Parser outher;
            public Usecase(Parser outher)
            {
                this.outher = outher;
            }
            public TypeNode Type()
            {
                if (outher.CurrentTokenType == TokenType.TypePrimitive
                    || outher.CurrentTokenType == TokenType.TypeOther)
                {
                    Token type = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TypeNode(type);
                }

                throw new SyntaxErrorException("文法が正しくありません");
            }
            public IdentifierNode Identifier()
            {
                if (outher.CurrentTokenType == TokenType.Identifier)
                {
                    Token identifier = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.IdentifierNode(identifier);
                }

                throw new SyntaxErrorException("文法が正しくありません");
            }
            public MemberFunctionNode Function()
            {
                return outher.ParseStaticMemberAccess();
            }
            public ExpressionNode Expression()
            {
                return outher.ParseExpression();
            }

            // --- ColoredToken ---

            public ColoredToken Member()
            {
                if (outher.CurrentTokenType == TokenType.Identifier)
                {
                    Token member = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TokenToColoredToken(member);
                }

                throw new SyntaxErrorException("文法が正しくありません");
            }
            public ColoredToken Equals()
            {
                if (outher.CurrentTokenType == TokenType.Equals)
                {
                    Token equal = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TokenToColoredToken(equal);
                }

                throw new SyntaxErrorException("=が必要です");
            }
            public ColoredToken Dot()
            {
                if (outher.CurrentTokenType == TokenType.Dot)
                {
                    Token dot = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TokenToColoredToken(dot);
                }
                throw new SyntaxErrorException(".が必要です");
            }
            public ColoredToken Semicolon()
            {
                if (outher.CurrentTokenType == TokenType.SemiColon)
                {
                    Token semicolon = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TokenToColoredToken(semicolon);
                }

                throw new SyntaxErrorException(";が必要です");
            }
            public ColoredToken If()
            {
                if (outher.CurrentTokenType == TokenType.If)
                {
                    Token @if = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TokenToColoredToken(@if);
                }
                throw new SyntaxErrorException("文法が正しくありません");
            }
            public ColoredToken Else()
            {
                if (outher.CurrentTokenType == TokenType.Else)
                {
                    Token @else = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TokenToColoredToken(@else);
                }
                throw new SyntaxErrorException("文法が正しくありません");
            }
            public ColoredToken While()
            {
                if (outher.CurrentTokenType == TokenType.If)
                {
                    Token @if = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TokenToColoredToken(@if);
                }
                throw new SyntaxErrorException("文法が正しくありません");
            }
            public ColoredToken LeftParen()
            {
                if (outher.CurrentTokenType == TokenType.LeftParen)
                {
                    Token leftParen = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TokenToColoredToken(leftParen);
                }
                throw new SyntaxErrorException("()が必要です");
            }
            public ColoredToken RightParen()
            {
                if (outher.CurrentTokenType == TokenType.RightParen)
                {
                    Token rightParen = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TokenToColoredToken(rightParen);
                }
                throw new SyntaxErrorException(")が必要です");
            }
            public ColoredToken LeftBrace()
            {
                if (outher.CurrentTokenType == TokenType.LeftBrace)
                {
                    Token leftBrace = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TokenToColoredToken(leftBrace);
                }
                throw new SyntaxErrorException("文法が正しくありません");
            }
            public ColoredToken RightBrace()
            {
                if (outher.CurrentTokenType == TokenType.RightBrace)
                {
                    Token rightBrace = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TokenToColoredToken(rightBrace);
                }
                throw new SyntaxErrorException("}が必要です");
            }
        }
    }
}

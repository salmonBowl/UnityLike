using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    partial class Parser
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
                TypeNode retval;
                if (outher.CurrentTokenType == TokenType.TypeStandard)
                {
                    retval = new(outher.CurrentToken.Value);
                    outher.Consume();
                }
                else
                {
                    throw new SyntaxErrorException();
                }
                return retval;
            }
            public IdentifierNode Identifier()
            {
                IdentifierNode retval;
                if (outher.CurrentTokenType == TokenType.Identifier)
                {
                    retval = ASTFactory.IdentifierNode(outher.CurrentToken);
                    outher.Consume();
                }
                else
                {
                    throw new SyntaxErrorException();
                }
                return retval;
            }
            public ColoredToken Equals()
            {
                if (outher.CurrentTokenType == TokenType.Equals)
                {
                    outher.Consume();
                }
                else
                {
                    throw new SyntaxErrorException();
                }
                return ASTFactory.TokenToColoredToken(outher.CurrentToken);
            }
            public ColoredToken Cemicolon()
            {
                if (outher.CurrentTokenType == TokenType.SemiColon)
                {
                    Token cemicolon = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TokenToColoredToken(cemicolon);
                }
                return null;
            }
            public ExpressionNode Expression()
            {
                return outher.ParseExpression();
            }
        }
    }
}

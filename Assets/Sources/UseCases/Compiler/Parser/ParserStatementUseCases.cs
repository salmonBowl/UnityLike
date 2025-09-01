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
                TypeNode retval;
                if (outher.CurrentTokenType == TokenType.TypeStandard)
                {
                    retval = ASTFactory.TypeNode(outher.CurrentToken);
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
                    Token equal = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TokenToColoredToken(equal);
                }
                else
                {
                    throw new SyntaxErrorException();
                }
            }
            public ColoredToken Semicolon()
            {
                if (outher.CurrentTokenType == TokenType.SemiColon)
                {
                    Token semicolon = outher.CurrentToken;
                    outher.Consume();
                    return ASTFactory.TokenToColoredToken(semicolon);
                }
                return null;
            }
            public ExpressionNode Expression()
            {
                return outher.ParseExpression();
            }
            public VariableNode Variable()
            {
                return outher.ParseVariable();
            }
        }
    }
}

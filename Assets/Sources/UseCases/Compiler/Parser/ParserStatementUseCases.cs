using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    partial class Parser
    {
        private class SyntaxErrorException : System.Exception { }

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
            public int Equals()
            {
                if (outher.CurrentTokenType == TokenType.Equals)
                {
                    outher.Consume();
                }
                else
                {
                    throw new SyntaxErrorException();
                }
                return 0;
            }
            public bool Cemicolon()
            {
                if (outher.CurrentTokenType == TokenType.SemiColon)
                {
                    outher.Consume();
                    return true;
                }
                return false;
            }
            public ExpressionNode Expression()
            {
                return outher.ParseExpression();
            }
        }
    }
}
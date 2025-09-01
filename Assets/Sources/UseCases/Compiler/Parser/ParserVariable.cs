using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    public partial class Parser
    {
        private VariableNode ParseVariable()
        {
            Token identifier = CurrentToken;
            if (CurrentTokenType == TokenType.Identifier)
                Consume();
            else
                throw new SyntaxErrorException("•s–¾‚È•¶š—ñ‚Å‚·");

            return MemberAccess(ASTFactory.IdentifierNode(identifier));
        }
        private VariableNode MemberAccess(VariableNode parent)
        {
            Token dot = CurrentToken;
            if (CurrentTokenType == TokenType.Dot)
                Consume();
            else
                return parent;

            Token member = CurrentToken;
            if (CurrentTokenType == TokenType.Identifier)
                Consume();
            else
                throw new SyntaxErrorException("–³Œø‚Èƒƒ“ƒo[–¼‚Å‚·");

            return ASTFactory.MemberAccessNode(parent, dot, member);
        }
    }
}

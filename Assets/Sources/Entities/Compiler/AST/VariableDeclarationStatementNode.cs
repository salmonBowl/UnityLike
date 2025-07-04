
namespace UnityLike.Entities.Compiler
{
    public class VariableDeclarationStatementNode : StatementNode
    {
        // ã^éóìIÇ»é¿ëï
        // åªç›ÇÕÇ±ÇÃíÜÇ…TokenType.TypeStandardÇìnÇµÇ‹Ç∑
        public TokenType Type;
        public IdentifierNode Identifier { get; }
#nullable enable
        public ExpressionNode? InitalValue { get; }

        public VariableDeclarationStatementNode(
            TokenType type,
            IdentifierNode identifier,
            ExpressionNode initalValue
            )
            : this(type, identifier)
        {
            InitalValue = initalValue;
        }
        public VariableDeclarationStatementNode(TokenType type, IdentifierNode identifier)
        {
            Type = type;
            Identifier = identifier;
        }
    }
}
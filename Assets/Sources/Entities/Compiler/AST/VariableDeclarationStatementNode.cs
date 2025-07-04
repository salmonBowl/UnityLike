
namespace UnityLike.Entities.Compiler
{
    public class VariableDeclarationStatementNode : StatementNode
    {
        // �^���I�Ȏ���
        // ���݂͂��̒���TokenType.TypeStandard��n���܂�
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
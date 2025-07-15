
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// ������m�[�h
    /// int x = 0 �Ȃ�
    /// </summary>
    public class VariableDeclarationStatementNode : StatementNode
    {
        // �^���I�Ȏ��������Ă��܂�
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
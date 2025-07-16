#nullable enable

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
        public TypeNode Type;
        public IdentifierNode Identifier { get; }
        public ExpressionNode? InitalValue { get; }

        public VariableDeclarationStatementNode(
            TypeNode type,
            IdentifierNode identifier,
            ExpressionNode initalValue
            )
            : this(type, identifier)
        {
            InitalValue = initalValue;
        }
        public VariableDeclarationStatementNode(TypeNode type, IdentifierNode identifier)
        {
            Type = type;
            Identifier = identifier;
        }
    }
}
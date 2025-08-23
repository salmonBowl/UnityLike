#nullable enable

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 代入式ノード
    /// int x = 0 など
    /// </summary>
    public class VariableDeclarationStatementNode : StatementNode
    {
        // 疑似的な実装をしています
        // 現在はこの中にTokenType.TypeStandardを渡します
        public TypeNode Type;
        public DeclaratedIdentifierNode DeclaratedIdentifier { get; }
        public AssignmentStatementNode? InitalAssignment { get; } = null;

        public VariableDeclarationStatementNode(TypeNode type, IdentifierNode identifier)
        {
            Type = type;
            DeclaratedIdentifier = new DeclaratedIdentifierNode(identifier);
        }
        public VariableDeclarationStatementNode(
            TypeNode type,
            IdentifierNode identifier,
            ExpressionNode initalValue
            ) : this(type, identifier)
        {
            InitalAssignment = new AssignmentStatementNode(identifier, initalValue);
        }
        public override void LogThis()
        {
            Type.LogThis();
            DeclaratedIdentifier.LogThis();
            InitalAssignment?.LogThis();
        }
        public override string ToPrettyString() =>
            Type.ToPrettyString() +
            ((InitalAssignment == null) ?
            $" {DeclaratedIdentifier};" :
            InitalAssignment.ToPrettyString());
        public override void ASTScan(ISemanticAnalyzer semantic)
        {
            // StatementNodeでは自分自身の意味解析のみ行います
            semantic.VisitVariableDeclarationStatement(this);
        }
    }
}
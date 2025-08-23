#nullable enable

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 変数宣言の式を表すノードです
    /// </summary>
    /*
     *  表現する式 : int x = 0;
     *  データ構造 : 変数宣言式(int x ; , 代入式(x = 0 ;))
     *  実際の形式 : VariableDeclarationStatementNode(TypeNode, DeclaratedIdentifierNode, AssignmentStatementNode);
     */
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
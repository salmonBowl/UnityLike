
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 変数へ代入する式を表すノードです
    /// </summary>
    /*
     *  表現する式 : x = 5;
     *  データ構造 : 代入式(型, 値)
     */
    public class AssignmentStatementNode : StatementNode
    {
        public IdentifierNode Identifier { get; }
        public ExpressionNode Value { get; }

        public AssignmentStatementNode(
            IdentifierNode identifier,
            ExpressionNode value
            )
        {
            Identifier = identifier;
            Value = value;
        }
        public override void LogThis()
        {
            Identifier.LogThis();
            Value.LogThis();
        }
        public override string ToPrettyString() =>
            $"{Identifier.ToPrettyString()} = {Value.ToPrettyString()};";

        public override void ASTScan(ISemanticAnalyzer semantic)
        {
            // StatementNodeでは自分自身の意味解析のみ行います
            semantic.VisitAssignmentStatement(this);
        }
    }
}
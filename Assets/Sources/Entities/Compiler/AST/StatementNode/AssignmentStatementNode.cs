
namespace UnityLike.Entities.Compiler
{
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
            // StatementNode‚Å‚Í©•ª©g‚ÌˆÓ–¡‰ğÍ‚Ì‚İs‚¢‚Ü‚·
            semantic.VisitAssignmentStatement(this);
        }
    }
}
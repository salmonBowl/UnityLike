
namespace UnityLike.Entities.Compiler
{
    public class AsignmentStatementNode : StatementNode
    {
        public IdentifierNode Identifier { get; }
        public ExpressionNode Value { get; }

        public AsignmentStatementNode(
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
        public override string ToPrettyString() => $"{Identifier.ToPrettyString()} = {Value};";
    }
}
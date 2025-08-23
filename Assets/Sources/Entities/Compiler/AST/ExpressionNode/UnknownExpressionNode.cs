
namespace UnityLike.Entities.Compiler
{
    public class UnknownExpressionNode : ExpressionNode
    {
        public string Value { get; }

        public UnknownExpressionNode(string value)
        {
            Value = value;
        }

        public override void LogThis()
        {
            UnityEngine.Debug.Log("Unknown : " + Value);
        }
        public override string ToPrettyString() => Value;
        public override void ASTScan(ISemanticAnalyzer semantic)
        {
            // UnknownExpression‚ÅˆÓ–¡‰ğÍ‚Í‚È‚µ
        }
    }
}
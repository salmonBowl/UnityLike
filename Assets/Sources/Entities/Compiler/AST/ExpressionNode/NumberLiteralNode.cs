
namespace UnityLike.Entities.Compiler
{
    public class NumberLiteralNode : ExpressionNode
    {
        public int Value { get; }

        public NumberLiteralNode(int value)
        {
            Value = value;
        }

        public override void LogThis()
        {
            UnityEngine.Debug.Log("Number : " + Value);
        }
        public override string ToPrettyString() => Value.ToString();
        public override void ASTScan(ISemanticAnalyzer semantic)
        {
            // ˆÓ–¡‰ğÍ‚ğ‚µ‚Ü‚·
            semantic.VisitNumberLiteral(this);
        }
    }
}

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
    }
}
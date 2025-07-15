
namespace UnityLike.Entities.Compiler
{
    public class UnknownNode : ExpressionNode
    {
        public string Value { get; }

        public UnknownNode(string value)
        {
            Value = value;
        }

        public override void LogThis()
        {
            UnityEngine.Debug.Log("Unknown : " + Value);
        }
    }
}
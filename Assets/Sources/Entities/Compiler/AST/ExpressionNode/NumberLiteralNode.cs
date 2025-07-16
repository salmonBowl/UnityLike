
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
    }
}
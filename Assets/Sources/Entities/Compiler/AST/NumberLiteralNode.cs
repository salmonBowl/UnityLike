
namespace UnityLike.Entities.Compiler
{
    public class NumberLiteralNode : ExpressionNode
    {
        public int Value { get; }
        
        public NumberLiteralNode(int value)
        {
            Value = value;
        }
    }
}
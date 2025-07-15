
namespace UnityLike.Entities.Compiler
{
    public class ParenNode : ExpressionNode
    {
        public ExpressionNode Content { get; }
        public ParenNode(ExpressionNode content)
        {
            Content = content;
        }
    }
}
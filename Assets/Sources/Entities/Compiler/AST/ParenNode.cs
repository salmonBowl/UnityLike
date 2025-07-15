
namespace UnityLike.Entities.Compiler
{
    public class ParenNode : ExpressionNode
    {
        public ExpressionNode Content { get; }

        public ParenNode(ExpressionNode content)
        {
            Content = content;
        }

        public override void LogThis()
        {
            UnityEngine.Debug.Log("Paren : (");
            Content.LogThis();
            UnityEngine.Debug.Log("Paren : )");
        }
    }
}
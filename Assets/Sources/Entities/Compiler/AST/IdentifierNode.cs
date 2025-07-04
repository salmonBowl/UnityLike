
namespace UnityLike.Entities.Compiler
{
    public class IdentifierNode : ExpressionNode
    {
        public string Name { get; }

        public IdentifierNode(string name)
        {
            Name = name;
        }
    }
}

namespace UnityLike.Entities.Compiler
{
    public class IdentifierNode : ExpressionNode
    {
        public string Name { get; }

        public IdentifierNode(string name)
        {
            Name = name;
        }

        public override void LogThis()
        {
            UnityEngine.Debug.Log("Identifier : " + Name);
        }
    }
}
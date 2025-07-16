
namespace UnityLike.Entities.Compiler
{
    public class TypeNode : Node
    {
        public string Name { get; }
        public TypeNode(string name)
        {
            Name = name;
        }
    }
}
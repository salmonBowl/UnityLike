
namespace UnityLike.Entities.Compiler
{
    public class TypeNode : Node
    {
        public string Name { get; }
        public TypeNode(string name)
        {
            Name = name;
        }
        public override void LogThis()
        {
            UnityEngine.Debug.Log("Type : " + Name);
        }
        public override string ToPrettyString() => Name;
    }
}
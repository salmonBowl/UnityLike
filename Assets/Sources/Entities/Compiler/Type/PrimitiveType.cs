
namespace UnityLike.Entities.Compiler
{
    public class PrimitiveType : TypeBase
    {
        public override string Name { get; }
        public override bool IsPrimitive { get; } = false;
        public PrimitiveType(string name) => Name = name;
    }
}
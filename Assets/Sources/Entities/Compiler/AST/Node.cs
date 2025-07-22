
namespace UnityLike.Entities.Compiler
{
    public abstract class Node
    {
        public virtual void LogThis() { }
        public abstract string ToPrettyString();
    }
}
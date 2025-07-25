
namespace UnityLike.Entities.Compiler
{
    public abstract class Node
    {
        public abstract void LogThis();
        public abstract string ToPrettyString();
        public abstract void ASTScan(ISemanticAnalizer semantic);
    }
}
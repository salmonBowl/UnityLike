
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
        public override string ToPrettyString() => Name;
        public override void ASTScan(ISemanticAnalyzer semantic)
        {
            // ˆÓ–¡‰ğÍ‚ğ‚µ‚Ü‚·
            semantic.VisitIdentifier(this);
        }
    }
}
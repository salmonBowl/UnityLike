
namespace UnityLike.Entities.Compiler
{
    public class DeclaratedIdentifierNode : ExpressionNode
    {
        public string Name { get; }
        public IdentifierNode Identifier { get; }

        public DeclaratedIdentifierNode(string name)
        {
            Name = name;
            Identifier = new IdentifierNode(name);
        }
        public DeclaratedIdentifierNode(IdentifierNode matrix)
        {
            Name = matrix.Name;
            Identifier = matrix;
        }
        public override void LogThis()
        {
            UnityEngine.Debug.Log("DeclaratedIdentifier : " + Name);
            Identifier.LogThis();
        }
        public override string ToPrettyString() => Identifier.ToPrettyString();
        public override void ASTScan(ISemanticAnalyzer semantic)
        {
            // Identifier‚Å‚Í‚È‚¢‚½‚ßIdentifier‚ÌˆÓ–¡‰ğÍ‚Ís‚¢‚Ü‚¹‚ñ
            // ©•ª©g
            semantic.VisitDeclaratedIdentifier(this);
        }
    }
}
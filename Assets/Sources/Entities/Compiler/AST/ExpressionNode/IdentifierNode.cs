
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 識別子を表現するノードです。Expressionの木構造の末端に位置します。
    /// </summary>
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
            // 意味解析をします
            semantic.VisitIdentifier(this);
        }
    }
}
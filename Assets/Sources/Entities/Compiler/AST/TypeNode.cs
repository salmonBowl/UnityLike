
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 構文木のうち型を表現するノードです。StatementNodeの構成要素になります。
    /// </summary>
    /*
        Expressionとは全く違う扱いをするため、ExpressionNodeではなくNodeから継承しています
        VariableDeclarationStatementNodeなどで使用されます
     */
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
        public override void ASTScan(ISemanticAnalyzer semantic)
        {
            // 意味解析をします
            semantic.VisitTypeNode(this);
        }
    }
}

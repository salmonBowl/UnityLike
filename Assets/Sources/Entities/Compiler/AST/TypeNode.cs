
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
        public ColoredToken NameToken { get; }

        public TypeNode(ColoredToken type)
        {
            Name = type.Value;
            NameToken = type;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            rebuilder.ImportColoredToken(NameToken);
        }

        public override string ToPrettyString() => Name;
        public override void ASTScan(IInterpreter interpreter)
        {
            // 意味解析をします
            interpreter.VisitTypeNode(this);
        }
    }
}

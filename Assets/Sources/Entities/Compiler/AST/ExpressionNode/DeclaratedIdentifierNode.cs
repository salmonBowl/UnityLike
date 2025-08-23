
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 変数の宣言時に命名の部分を構成するノードです。IdentifierNodeを包む形を採用しています。
    /// </summary>
    // VariableDeclarationStatementNodeなどで使用されます
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
            // 内部のIdentifierには意味解析の機能を持たせず、自分自身のみ解析します
            semantic.VisitDeclaratedIdentifier(this);
        }
    }
}
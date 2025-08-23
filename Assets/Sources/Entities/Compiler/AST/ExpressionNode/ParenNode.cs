
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 丸かっこを表現するノードです。Expressionをかっこで包み、これ自身もまたExpressionになります。
    /// </summary>
    public class ParenNode : ExpressionNode
    {
        public ExpressionNode Content { get; }

        public ParenNode(ExpressionNode content)
        {
            Content = content;
        }

        public override void LogThis()
        {
            UnityEngine.Debug.Log("Paren : (");
            Content.LogThis();
            UnityEngine.Debug.Log("Paren : )");
        }
        public override string ToPrettyString() => $"({Content.ToPrettyString()})";
        public override void ASTScan(ISemanticAnalyzer semantic)
        {
            // 再帰呼び出し
            Content.ASTScan(semantic);
            // 自分自身
            semantic.VisitParenExpression(this);
        }
    }
}
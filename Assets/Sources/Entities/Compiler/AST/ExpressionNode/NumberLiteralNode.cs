
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 数字リテラルを表現するノードです。Expressionの木構造の末端に位置します。
    /// </summary>
    public class NumberLiteralNode : ExpressionNode
    {
        public int Value { get; }

        public NumberLiteralNode(int value)
        {
            Value = value;
        }

        public override string ToPrettyString() => Value.ToString();
        public override void ASTScan(ISemanticAnalyzer semantic)
        {
            // 意味解析をします
            semantic.VisitNumberLiteral(this);
        }
    }
}
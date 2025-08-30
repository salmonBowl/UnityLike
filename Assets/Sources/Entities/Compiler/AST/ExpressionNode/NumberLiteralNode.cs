
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 数字リテラルを表現するノードです。Expressionの木構造の末端に位置します。
    /// </summary>
    public class NumberLiteralNode : ExpressionNode
    {
        public int Value { get; }
        public ColoredToken NumberToken { get; }

        public NumberLiteralNode(int value, ColoredToken numberToken)
        {
            Value = value;
            NumberToken = numberToken;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            rebuilder.ImportColoredToken(NumberToken);
        }

        public override string ToPrettyString() => Value.ToString();
        public override void ASTScan(IInterpreter interpreter)
        {
            // 意味解析をします
            interpreter.VisitNumberLiteral(this);
        }
    }
}
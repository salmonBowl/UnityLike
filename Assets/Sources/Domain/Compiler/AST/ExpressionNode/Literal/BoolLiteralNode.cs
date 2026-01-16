using UnityLike.Entities.Symbol;

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// bool値リテラルを表現するノードです。Expressionの木構造の末端に位置します。
    /// </summary>
    public class BoolLiteralNode : ExpressionNode
    {
        public bool Value { get; }
        public ColoredToken ValueToken { get; }

        public BoolLiteralNode(bool value, ColoredToken valueToken)
        {
            Value = value;
            ValueToken = valueToken;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            rebuilder.ImportColoredToken(ValueToken);
        }

        public override string ToPrettyString() => Value.ToString();
        public override Instance ASTScan(IVisitor interpreter) => interpreter.VisitBoolLiteral(this);
    }
}

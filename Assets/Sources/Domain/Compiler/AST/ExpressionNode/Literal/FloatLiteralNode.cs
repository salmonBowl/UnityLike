using UnityLike.Entities.Symbol;

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 数字リテラルを表現するノードです。Expressionの木構造の末端に位置します。
    /// </summary>
    public class FloatLiteralNode : NumberLiteralNode
    {
        public float Value { get; }
        public ColoredToken NumberToken { get; }

        public FloatLiteralNode(float value, ColoredToken numberToken)
        {
            Value = value;
            NumberToken = numberToken;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            rebuilder.ImportColoredToken(NumberToken);
        }

        public override string ToPrettyString() => Value.ToString();
        public override Instance ASTScan(IVisitor interpreter) => interpreter.VisitFloatLiteral(this);
    }
}

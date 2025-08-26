
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 不明な文字列を格納します。現在は字句解析で起こった例外をExpressionを継承したこのノードで表現しています。
    /// </summary>
    public class UnknownExpressionNode : ExpressionNode
    {
        public string Value { get; }
        public ColoredToken UnknownToken { get; }

        public UnknownExpressionNode(string value)
        {
            Value = value;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            rebuilder.ImportColoredToken(UnknownToken);
        }

        public override string ToPrettyString() => Value;
        public override void ASTScan(ISemanticAnalyzer semantic)
        {
            // UnknownExpressionで意味解析はなし
        }
    }
}
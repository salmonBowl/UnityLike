
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 丸かっこを表現するノードです。Expressionをかっこで包み、これ自身もまたExpressionになります。
    /// </summary>
    public class ParenNode : ExpressionNode
    {
        public ColoredToken LeftParenToken { get; }
        public ExpressionNode Content { get; }
        public ColoredToken RightParenToken { get; }

        public ParenNode(ColoredToken leftParenToken, ExpressionNode content, ColoredToken rightParenToken)
        {
            LeftParenToken = leftParenToken;
            Content = content;
            RightParenToken = rightParenToken;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            rebuilder.ImportColoredToken(LeftParenToken);
            Content.ColoredTokenScan(rebuilder);
            rebuilder.ImportColoredToken(RightParenToken);
        }

        public override string ToPrettyString() => $"({Content.ToPrettyString()})";
        public override void ASTScan(IInterpreter interpreter)
        {
            // 再帰呼び出し
            Content.ASTScan(interpreter);
            // 自分自身
            interpreter.VisitParenExpression(this);
        }
    }
}
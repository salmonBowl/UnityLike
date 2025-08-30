
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 識別子を表現するノードです。Expressionの木構造の末端に位置します。
    /// </summary>
    public class IdentifierNode : ExpressionNode
    {
        public string Name { get; }
        public ColoredToken IdentifierToken { get; }

        public IdentifierNode(ColoredToken identifierToken)
        {
            Name = identifierToken.Value;
            IdentifierToken = identifierToken;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            rebuilder.ImportColoredToken(IdentifierToken);
        }

        public override string ToPrettyString() => Name;
        public override void ASTScan(IInterpreter interpreter)
        {
            // 意味解析をします
            interpreter.VisitIdentifier(this);
        }
    }
}
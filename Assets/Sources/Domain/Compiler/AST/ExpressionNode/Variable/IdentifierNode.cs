using UnityLike.Entities.Symbol;

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 識別子を表現するノードです。Expressionの木構造の末端に位置します。
    /// </summary>
    public class IdentifierNode : VariableNode
    {
        public string Name { get; }
        public ColoredToken IdentifierToken { get; }

        public IdentifierNode(ColoredToken variableToken)
        {
            Name = variableToken.Value;
            IdentifierToken = variableToken;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            rebuilder.ImportColoredToken(IdentifierToken);
        }

        public override string ToPrettyString() => Name;
        public override Variable GetVariable(IVisitor interpreter) => interpreter.GetIdentifier(this);
    }
}
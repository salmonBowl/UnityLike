
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 変数へ代入する式を表すノードです
    /// </summary>
    /*
     *  表現する式 : x = 5;
     *  データ構造 : 代入式(型, 値)
     */
    public class AssignmentStatementNode : StatementNode
    {
        public VariableNode Variable { get; }
        public ExpressionNode Value { get; }

        public ColoredToken EqualToken { get; }
        public ColoredToken SemicolonToken { get; }

        public AssignmentStatementNode(VariableNode variable, ColoredToken equalToken,
            ExpressionNode value, ColoredToken semicolonToken)
        {
            Variable = variable;
            Value = value;
            EqualToken = equalToken;
            SemicolonToken = semicolonToken;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            Variable.ColoredTokenScan(rebuilder);
            rebuilder.ImportColoredToken(EqualToken);
            Value.ColoredTokenScan(rebuilder);
            rebuilder.ImportColoredToken(SemicolonToken);
        }

        public override string ToPrettyString() =>
            $"{Variable.ToPrettyString()} = {Value.ToPrettyString()};";

        public override void ASTScan(IVisitor interpreter)
        {
            interpreter.ExecuteAssignmentStatement(this);
        }
    }
}


namespace UnityLike.Entities.Compiler
{
    public class WhileStatementNode : StatementNode
    {
        public ExpressionNode Condition { get; }
        public StatementNode Statement { get; }

        public ColoredToken WhileToken { get; }
        public ColoredToken LeftParenToken { get; }
        public ColoredToken RightParenToken { get; }

        public WhileStatementNode(ColoredToken whileToken, ColoredToken leftParen, ExpressionNode condition, ColoredToken rightParen, StatementNode statement)
        {
            Condition = condition;
            Statement = statement;
            WhileToken = whileToken;
            LeftParenToken = leftParen;
            RightParenToken = rightParen;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            rebuilder.ImportColoredToken(WhileToken);
            rebuilder.ImportColoredToken(LeftParenToken);
            Condition.ColoredTokenScan(rebuilder);
            rebuilder.ImportColoredToken(RightParenToken);
            Statement.ColoredTokenScan(rebuilder);
        }

        public override string ToPrettyString()
        {
            string retval = string.Empty;

            retval += $"while ({Condition.ToPrettyString()})\n";
            retval += Statement.ToPrettyString();
            return retval;
        }

        public override void ASTScan(IVisitor interpreter)
        {
            interpreter.ExecuteWhileStatement(this);
        }
    }
}

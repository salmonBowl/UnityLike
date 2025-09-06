#nullable enable

namespace UnityLike.Entities.Compiler
{
    public class IfStatementNode : StatementNode
    {
        public ExpressionNode Condition { get; }

        public StatementNode Then { get; }
        public StatementNode? Else { get; }

        public ColoredToken IfToken { get; }
        public ColoredToken LeftParenToken { get; }
        public ColoredToken RightParenToken { get; }
        public ColoredToken? ElseToken { get; }

        public IfStatementNode(ColoredToken ifToken, ColoredToken leftParen, ExpressionNode condition, ColoredToken rightParen, StatementNode thenStatement)
        {
            Condition = condition;
            Then = thenStatement;
            IfToken = ifToken;
            LeftParenToken = leftParen;
            RightParenToken = rightParen;
        }
        public IfStatementNode(ColoredToken ifToken, ColoredToken leftParen, ExpressionNode condition, ColoredToken rightParen, StatementNode thenStatement,
            ColoredToken elseToken, StatementNode elseStatement)
            : this(ifToken, leftParen, condition, rightParen, thenStatement)
        {
            Else = elseStatement;
            ElseToken = elseToken;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            rebuilder.ImportColoredToken(IfToken);
            rebuilder.ImportColoredToken(LeftParenToken);
            Condition.ColoredTokenScan(rebuilder);
            rebuilder.ImportColoredToken(RightParenToken);

            Then.ColoredTokenScan(rebuilder);

            if (ElseToken != null) rebuilder.ImportColoredToken(ElseToken);
            Else?.ColoredTokenScan(rebuilder);
        }

        public override string ToPrettyString()
        {
            string retval = string.Empty;

            retval += $"if ({Condition.ToPrettyString()})\n";
            retval += Then.ToPrettyString();
            if (ElseToken != null)
            {
                retval += "\nelse\n";
                retval += Else?.ToPrettyString();
            }
            return retval;
        }

        public override void ASTScan(IVisitor interpreter)
        {
            interpreter.ExecuteIfStatement(this);
        }
    }
}

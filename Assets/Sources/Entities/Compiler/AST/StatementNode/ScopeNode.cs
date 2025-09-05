using System.Collections.Generic;

using UnityLike.Entities.Symbol;

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// スコープを表現するクラスです。List<Statements>を持ちます。
    /// </summary>
    public abstract class ScopeNode : StatementNode
    {
        public List<StatementNode> Statements { get; }

        public ColoredToken LeftBraceToken { get; }
        public ColoredToken RightBraceToken { get; }

        public ScopeNode(ColoredToken leftBrace, List<StatementNode> statements, ColoredToken rightBrace)
        {
            Statements = statements;
            LeftBraceToken = leftBrace;
            RightBraceToken = rightBrace;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            rebuilder.ImportColoredToken(LeftBraceToken);
            foreach (var statement in Statements)
            {
                statement.ColoredTokenScan(rebuilder);
            }
            rebuilder.ImportColoredToken(RightBraceToken);
        }

        public override string ToPrettyString()
        {
            string retval = string.Empty;

            retval += "{\n";
            foreach (var statement in Statements)
            {
                retval += statement.ToPrettyString();
            }
            retval += "\n}";

            return retval;
        }

        public override void ASTScan(IVisitor interpreter)
        {
            interpreter.ExecuteScope(this);
        }
    }
}

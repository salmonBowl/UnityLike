using System.Collections.Generic;

using UnityLike.Entities.Symbol;

namespace UnityLike.Entities.Compiler
{
    public class NewExpressionNode : ExpressionNode
    {
        public string ClassName { get; }
        public ExpressionNode[] Arguments { get; }
        public ColoredToken NewToken { get; }
        public ColoredToken ClassNameToken { get; }
        public ColoredToken LeftParenToken { get; }
        public ColoredToken[] CommaTokens { get; }
        public ColoredToken RightParenToken { get; }

        public NewExpressionNode(ColoredToken newToken, ColoredToken classToken, ColoredToken leftParen, ExpressionNode[] arguments, ColoredToken[] commas, ColoredToken rightParen)
        {
            ClassName = classToken.Value;
            Arguments = arguments;
            NewToken = newToken;
            ClassNameToken = classToken;
            LeftParenToken = leftParen;
            CommaTokens = commas;
            RightParenToken = rightParen;
        }
        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            rebuilder.ImportColoredToken(NewToken);
            rebuilder.ImportColoredToken(LeftParenToken);
            rebuilder.ImportColoredToken(LeftParenToken);
            for (int i = 0; i < Arguments.Length; i++)
            {
                if (i != 0)
                    rebuilder.ImportColoredToken(CommaTokens[i - 1]);

                Arguments[i].ColoredTokenScan(rebuilder);
            }
            rebuilder.ImportColoredToken(RightParenToken);
        }

        public override string ToPrettyString()
        {
            string arguments = string.Empty;
            for (int i = 0; i < Arguments.Length; i++)
            {
                if (i != 0)
                    arguments += ", ";

                arguments += Arguments[i].ToPrettyString();
            }
            return $"new {ClassName}({arguments})";
        }

        public override Instance ASTScan(IVisitor interpreter) => interpreter.VisitNewExpression(this);
    }
}
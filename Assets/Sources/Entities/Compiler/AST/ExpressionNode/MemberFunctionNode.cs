#nullable enable

using UnityLike.Entities.Symbol;

namespace UnityLike.Entities.Compiler
{
    public class MemberFunctionNode : ExpressionNode
    {
        public VariableNode? ParentVariable { get; }
        public TypeNode? ParentClass { get; }
        public string MemberName { get; }
        public ExpressionNode[] Arguments { get; }
        public ColoredToken Dot { get; }
        public ColoredToken MemberNameToken { get; }
        public ColoredToken LeftParenToken { get; }
        public ColoredToken[] CommaTokens { get; }
        public ColoredToken RightParenToken { get; }

        public MemberFunctionNode(VariableNode parent, ColoredToken dot, ColoredToken member,
            ColoredToken leftParen, ExpressionNode[] arguments, ColoredToken[] commas, ColoredToken rightParen)
        {
            ParentVariable = parent;
            MemberName = member.Value;
            Dot = dot;
            MemberNameToken = member;
            Arguments = arguments;
            LeftParenToken = leftParen;
            CommaTokens = commas;
            RightParenToken = rightParen;
        }
        public MemberFunctionNode(TypeNode parent, ColoredToken dot, ColoredToken member,
            ColoredToken leftParen, ExpressionNode[] arguments, ColoredToken[] commas, ColoredToken rightParen)
        {
            ParentClass = parent;
            MemberName = member.Value;
            Dot = dot;
            MemberNameToken = member;
            Arguments = arguments;
            LeftParenToken = leftParen;
            CommaTokens = commas;
            RightParenToken = rightParen;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            ParentVariable?.ColoredTokenScan(rebuilder);
            ParentClass?.ColoredTokenScan(rebuilder);
            rebuilder.ImportColoredToken(Dot);
            rebuilder.ImportColoredToken(MemberNameToken);
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
            string parent = string.Empty;
            if (ParentVariable != null) parent = ParentVariable.ToPrettyString();
            if (ParentClass != null) parent = ParentClass.ToPrettyString();
            string arguments = string.Empty;
            for (int i = 0; i < Arguments.Length; i++)
            {
                if (i != 0)
                    arguments += ", ";

                arguments += Arguments[i].ToPrettyString();
            }
            return $"{parent}.{MemberName}({arguments})";
        }

        public override Instance ASTScan(IVisitor interpreter) => interpreter.ExecuteMemberFunction(this);
    }
}

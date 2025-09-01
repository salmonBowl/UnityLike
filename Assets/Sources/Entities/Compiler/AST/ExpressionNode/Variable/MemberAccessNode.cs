using UnityLike.Entities.Symbol;
using UnityLike.UseCases.Interpreter;

namespace UnityLike.Entities.Compiler
{
    public class MemberAccessNode : VariableNode
    {
        public VariableNode ParentVariable { get; }
        public string MemberName { get; }
        public ColoredToken Dot { get; }
        public ColoredToken MemberNameToken { get; }

        public MemberAccessNode(VariableNode parent, ColoredToken dot, ColoredToken member)
        {
            ParentVariable = parent;
            MemberName = member.Value;
            Dot = dot;
            MemberNameToken = member;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            ParentVariable.ColoredTokenScan(rebuilder);
            rebuilder.ImportColoredToken(Dot);
            rebuilder.ImportColoredToken(MemberNameToken);
        }

        public override string ToPrettyString() =>
            ParentVariable.ToPrettyString() + "." + MemberName;

        public override Variable GetVariable(IVisitor interpreter) => interpreter.GetMemberAccess(this);
    }
}

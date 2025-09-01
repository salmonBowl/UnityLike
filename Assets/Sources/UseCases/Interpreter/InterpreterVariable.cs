using UnityLike.Entities.Compiler;
using UnityLike.Entities.Symbol;

namespace UnityLike.UseCases.Interpreter
{
    public partial class Interpreter : IVisitor
    {
        public Variable GetIdentifier(IdentifierNode node)
        {
            return currentScope.LookUpVariable(node.Name)
                ?? throw new IdentifierNotFoundException(node.Name, node.IdentifierToken);
        }
        public Variable GetMemberAccess(MemberAccessNode node)
        {
            Instance parent = node.ParentVariable.GetVariable(this).Value;
            Variable member = parent.GetMember(node.MemberName, node.MemberNameToken);
            return member;
        }
    }
}

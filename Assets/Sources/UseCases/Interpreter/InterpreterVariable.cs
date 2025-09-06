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
        public Variable ExecuteMemberFunction(MemberFunctionNode node)
        {
            Instance parent = node.ParentVariable.GetVariable(this).Value;

            Instance[] args = new Instance[node.Arguments.Length];
            for (int i = 0; i < node.Arguments.Length; i++)
            {
                args[i] = node.Arguments[i].ASTScan(this);
            }

            Instance @return = parent.ExecuteMemberFuction(node.MemberName, args, node.MemberNameToken, node.RightParenToken);
            Variable function = new(@return, Class.Single);

            return function;
        }
    }
}

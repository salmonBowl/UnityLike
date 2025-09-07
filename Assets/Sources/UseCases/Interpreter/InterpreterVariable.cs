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
        public Instance ExecuteMemberFunction(MemberFunctionNode node)
        {
            // ParentVariable‚Ì—L–³‚Åˆ—‚ğ•ª‚¯‚Ä‚¢‚Ü‚·
            if (node.ParentVariable == null)
                return ExecuteStaticFunction(node);

            Instance parent = node.ParentVariable.GetVariable(this).Value;

            Instance[] args = new Instance[node.Arguments.Length];
            for (int i = 0; i < node.Arguments.Length; i++)
            {
                args[i] = node.Arguments[i].ASTScan(this);
            }

            Instance @return = parent.ExecuteMemberFuction(node.MemberName, args, node.MemberNameToken, node.RightParenToken);
            return @return;
        }
        private Instance ExecuteStaticFunction(MemberFunctionNode node)
        {
            string parentName = node.ParentClass.Name;
            Class parent = TypeRegistry.StaticMethodTypeOf(parentName, node.ParentClass.NameToken);

            Instance[] args = new Instance[node.Arguments.Length];
            for (int i = 0; i < node.Arguments.Length; i++)
            {
                args[i] = node.Arguments[i].ASTScan(this);
            }

            Instance @return = parent.ExecuteStaticFuction(node.MemberName, args, node.MemberNameToken, node.RightParenToken);
            return @return;
        }
    }
}

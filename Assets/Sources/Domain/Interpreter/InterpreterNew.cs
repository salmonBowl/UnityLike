using UnityLike.Entities.Compiler;
using UnityLike.Entities.Symbol;

namespace UnityLike.UseCases.Interpreter
{
    public partial class Interpreter : IVisitor
    {
        private readonly NewInstance instanceFactory = new();

        public Instance VisitNewExpression(NewExpressionNode node)
        {
            Instance[] args = new Instance[node.Arguments.Length];
            for (int i = 0; i < node.Arguments.Length; i++)
            {
                args[i] = node.Arguments[i].ASTScan(this);
            }

            return instanceFactory.ExecuteMemberFuction(node.ClassName, args, node.ClassNameToken, node.RightParenToken);
        }
    }
}

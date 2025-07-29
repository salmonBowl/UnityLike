using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    partial class SemanticAnalyzer : ISemanticAnalyzer
    {
        public void VisitTypeNode(TypeNode typeNode)
        {
            if (TypeConstants.Types.TryGetValue(typeNode.Name, out _) == false)
                throw new TypeNotFindException(typeNode.Name);
        }
        public void VisitBinaryExpression(BinaryExpressionNode bynaryExpression)
        {
            // –¢ŽÀ‘•
        }
        public void VisitIdentifier(IdentifierNode identifier)
        {
            // –¢ŽÀ‘•
        }
        public void VisitNumberLiteral(NumberLiteralNode numberLiteral)
        {
            // –¢ŽÀ‘•
        }
        public void VisitParenExpression(ParenNode parenExpression)
        {
            // –¢ŽÀ‘•
        }
        public void VisitUnaryExpression(UnaryExpressionNode unaryExpression)
        {
            // –¢ŽÀ‘•
        }
    }
}

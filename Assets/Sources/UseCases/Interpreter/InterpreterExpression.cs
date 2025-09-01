using UnityLike.Entities.Compiler;
using UnityLike.Entities.Symbol;

namespace UnityLike.UseCases.Interpreter
{
    public partial class Interpreter : IVisitor
    {
        public void VisitTypeNode(TypeNode typeNode)
        {
            if (TypeRegistry. == false)
                throw new TypeNotFoundException(typeNode.Name);
        }
        public void VisitBinaryExpression(BinaryExpressionNode bynaryExpression)
        {
            // ñ¢é¿ëï
        }
        public void VisitIdentifier(IdentifierNode identifier)
        {
            if (currentScope.LookUpVariable(identifier.Name) != null)
                throw new IdentifierNotFoundException(identifier.Name);
        }
        public void VisitDeclaratedIdentifier(DeclaratedIdentifierNode identifier)
        {
            // Ç±ÇÃÉmÅ[ÉhÇ…à”ñ°âêÕÇÃèàóùÇÕÇ†ÇËÇ‹ÇπÇÒ
        }
        public void VisitNumberLiteral(NumberLiteralNode numberLiteral)
        {
            // ñ¢é¿ëï
        }
        public void VisitParenExpression(ParenNode parenExpression)
        {
            // ñ¢é¿ëï
        }
        public void VisitUnaryExpression(UnaryExpressionNode unaryExpression)
        {
            // ñ¢é¿ëï
        }
    }
}

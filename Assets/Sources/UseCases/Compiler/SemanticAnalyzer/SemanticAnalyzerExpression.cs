using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    partial class SemanticAnalyzer : ISemanticAnalyzer
    {
        public void VisitTypeNode(TypeNode typeNode)
        {
            if (TypeConstants.definedTypes.TryGetValue(typeNode.Name, out _) == false)
                throw new TypeNotFoundException(typeNode.Name);
        }
        public void VisitBinaryExpression(BinaryExpressionNode bynaryExpression)
        {
            // ñ¢é¿ëï
        }
        public void VisitIdentifier(IdentifierNode identifier)
        {
            if (currentScope.LookUpSymbol(identifier.Name) != null)
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

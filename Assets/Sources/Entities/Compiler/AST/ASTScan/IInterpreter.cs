
namespace UnityLike.Entities.Compiler
{
    public interface IInterpreter
    {
        // Statement
        void VisitVariableDeclarationStatement(VariableDeclarationStatementNode node);
        void VisitAssignmentStatement(AssignmentStatementNode node);

        // Expression
        void VisitBinaryExpression(BinaryExpressionNode node);
        void VisitIdentifier(IdentifierNode node);
        void VisitDeclaratedIdentifier(DeclaratedIdentifierNode node);
        void VisitNumberLiteral(NumberLiteralNode node);
        void VisitParenExpression(ParenNode node);
        void VisitUnaryExpression(UnaryExpressionNode node);

        // Type
        void VisitTypeNode(TypeNode node);
    }
}
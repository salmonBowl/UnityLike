
namespace UnityLike.Entities.Compiler
{
    public interface IInterpreter
    {
        // Statement
        void ExecuteVariableDeclarationStatement(VariableDeclarationStatementNode node);
        void ExecuteAssignmentStatement(AssignmentStatementNode node);

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
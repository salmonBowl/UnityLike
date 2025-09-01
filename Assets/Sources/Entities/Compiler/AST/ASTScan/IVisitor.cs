using UnityLike.Entities.Symbol;

namespace UnityLike.Entities.Compiler
{
    public interface IVisitor
    {
        // Statement
        void ExecuteVariableDeclarationStatement(VariableDeclarationStatementNode node);
        void ExecuteAssignmentStatement(AssignmentStatementNode node);

        // Expression
        Instance VisitBinaryExpression(BinaryExpressionNode node);
        Instance VisitIdentifier(IdentifierNode node);
        Instance VisitDeclaratedIdentifier(DeclaratedIdentifierNode node);
        Instance VisitNumberLiteral(IntLiteralNode node);
        Instance VisitParenExpression(ParenNode node);
        Instance VisitUnaryExpression(UnaryExpressionNode node);
    }
}
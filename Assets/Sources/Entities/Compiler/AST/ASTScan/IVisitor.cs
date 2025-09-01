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
        Instance VisitVariable(VariableNode node);
        Instance VisitNumberLiteral(IntLiteralNode node);
        Instance VisitParenExpression(ParenNode node);
        Instance VisitUnaryExpression(UnaryExpressionNode node);
        Instance VisitNewExpression(NewExpressionNode node);

        // Variable
        Variable GetIdentifier(IdentifierNode node);
        Variable GetMemberAccess(MemberAccessNode node);
    }
}
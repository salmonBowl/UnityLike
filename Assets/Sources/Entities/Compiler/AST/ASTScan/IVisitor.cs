using UnityLike.Entities.Symbol;

namespace UnityLike.Entities.Compiler
{
    public interface IVisitor
    {
        // Statement
        void ExecuteVariableDeclarationStatement(VariableDeclarationStatementNode node);
        void ExecuteAssignmentStatement(AssignmentStatementNode node);
        void ExecuteIfStatement(IfStatementNode node);
        void ExecuteWhileStatement(WhileStatementNode node);
        void ExecuteScope(ScopeNode scope);

        // Expression
        Instance VisitBinaryExpression(BinaryExpressionNode node);
        Instance VisitVariable(VariableNode node);
        Instance VisitIntLiteral(IntLiteralNode node);
        Instance VisitFloatLiteral(FloatLiteralNode node);
        Instance VisitBoolLiteral(BoolLiteralNode node);
        Instance VisitParenExpression(ParenNode node);
        Instance VisitUnaryExpression(UnaryExpressionNode node);
        Instance VisitNewExpression(NewExpressionNode node);

        // Variable
        Variable GetIdentifier(IdentifierNode node);
        Variable GetMemberAccess(MemberAccessNode node);
    }
}
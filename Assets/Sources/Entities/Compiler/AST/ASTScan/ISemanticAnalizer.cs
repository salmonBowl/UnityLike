
namespace UnityLike.Entities.Compiler
{
    public interface ISemanticAnalizer
    {
        // 各StatementNodeに対応するVisitメソッド
        void VisitVariableDeclarationStatement(VariableDeclarationStatementNode node);
        void VisitAssignmentStatement(AssignmentStatementNode node);

        // 各ExpressionNodeに対応するVisitメソッド
        void VisitBinaryExpression(BinaryExpressionNode node);
        void VisitIdentifier(IdentifierNode node);
        void VisitNumberLiteral(NumberLiteralNode node);
        void VisitParenExpression(ParenNode node);
        void VisitUnaryExpression(UnaryExpressionNode node);
    }
}
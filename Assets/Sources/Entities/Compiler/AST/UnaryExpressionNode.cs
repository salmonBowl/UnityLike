
namespace UnityLike.Entities.Compiler
{
    public class UnaryExpressionNode : ExpressionNode
    {
        public TokenType Operator { get; }
        public ExpressionNode Operand { get; }

        public UnaryExpressionNode(
            TokenType @operator,
            ExpressionNode operand
            )
        {
            Operator = @operator;
            Operand = operand;
        }
    }
}

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// ’P€ƒm[ƒh
    /// -x‚â!x‚ğˆµ‚¢‚Ü‚·
    /// </summary>
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
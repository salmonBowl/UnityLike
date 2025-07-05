
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// �P���m�[�h
    /// -x��!x�������܂�
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
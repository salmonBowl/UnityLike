
namespace UnityLike.Entities.Compiler
{
    public class BinaryExpressionNode : ExpressionNode
    {
        //  1 + 1 �̂悤�ȃm�[�h

        public ExpressionNode LeftNode { get; }
        public TokenType Operator { get; }
        public ExpressionNode RightNode { get; }

        public BinaryExpressionNode(
            ExpressionNode leftNode,
            TokenType @operator,
            ExpressionNode rightNode
            )
        {
            LeftNode = leftNode;
            Operator = @operator;
            RightNode = rightNode;
        }
    }
}
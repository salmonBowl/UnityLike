
namespace UnityLike.Entities.Compiler
{
    public class BinaryExpressionNode : ExpressionNode
    {
        //  1 + 1 ÇÃÇÊÇ§Ç»ÉmÅ[Éh

        public ExpressionNode LeftNode { get; }
        public TokenType Operator { get; }
        public ExpressionNode RightNode { get; }

        public BinaryExpressionNode(
            ExpressionNode leftNode,
            TokenType _operator,
            ExpressionNode rightNode
            )
        {
            LeftNode = leftNode;
            Operator = _operator;
            RightNode = rightNode;
        }
    }
}

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
            TokenType @operator,
            ExpressionNode rightNode
            )
        {
            LeftNode = leftNode;
            Operator = @operator;
            RightNode = rightNode;
        }

        public override void LogThis()
        {
            UnityEngine.Debug.Log("Binary : " + Operator.ToString());
            UnityEngine.Debug.Log("left and right");
            LeftNode.LogThis();
            RightNode.LogThis();
        }
    }
}
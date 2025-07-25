
namespace UnityLike.Entities.Compiler
{
    public class BinaryExpressionNode : ExpressionNode
    {
        //  1 + 1 ‚Ì‚æ‚¤‚Èƒm[ƒh

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
        public override string ToPrettyString() => 
            LeftNode.ToPrettyString() + " " + 
            Operator switch
            {
                TokenType.Plus => "+",
                TokenType.Minus => "-",
                TokenType.Multiply => "*",
                TokenType.Divide => "/",
                _ => throw new System.NotSupportedException()
            }
            + " " + RightNode.ToPrettyString();
        public override void ASTScan(ISemanticAnalyzer semantic) =>
            semantic.VisitBinaryExpression(this);
    }
}
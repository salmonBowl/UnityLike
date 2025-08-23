
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 演算の構造を表すExpressionNodeです
    /// </summary>
    /*
        BynaryExpression(LeftNode, +, RightNode)
        → LeftNode + RightNode という値を表現
     */
    public class BinaryExpressionNode : ExpressionNode
    {
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
        public override void ASTScan(ISemanticAnalyzer semantic)
        {
            LeftNode.ASTScan(semantic);
            RightNode.ASTScan(semantic);
            semantic.VisitBinaryExpression(this);
        }
    }
}
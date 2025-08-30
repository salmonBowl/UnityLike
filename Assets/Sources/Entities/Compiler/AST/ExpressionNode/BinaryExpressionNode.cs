
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
        public ColoredToken OperatorToken { get; }
        public ExpressionNode RightNode { get; }

        public BinaryExpressionNode(
            ExpressionNode leftNode,
            TokenType @operator,
            ColoredToken operatorToken,
            ExpressionNode rightNode
            )
        {
            LeftNode = leftNode;
            Operator = @operator;
            OperatorToken = operatorToken;
            RightNode = rightNode;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            LeftNode.ColoredTokenScan(rebuilder);
            rebuilder.ImportColoredToken( OperatorToken );
            RightNode.ColoredTokenScan(rebuilder);
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
        public override void ASTScan(IInterpreter interpreter)
        {
            LeftNode.ASTScan(interpreter);
            RightNode.ASTScan(interpreter);
            interpreter.VisitBinaryExpression(this);
        }
    }
}
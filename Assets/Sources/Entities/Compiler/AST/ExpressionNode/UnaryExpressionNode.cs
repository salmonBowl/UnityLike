
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 単項演算を表すノードです
    /// </summary>
    //  例えば-xや!xを扱います
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

        public override void LogThis()
        {
            UnityEngine.Debug.Log("Unary : " + Operator.ToString());
            Operand.LogThis();
        }
        public override string ToPrettyString() =>
            Operator switch
            {
                TokenType.Minus => "-",
                _ => throw new System.Exception()
            }
            + Operand.ToPrettyString();
        public override void ASTScan(ISemanticAnalyzer semantic)
        {
            // 再帰呼び出し
            Operand.ASTScan(semantic);
            // 自分自身
            semantic.VisitUnaryExpression(this);
        }
    }
}
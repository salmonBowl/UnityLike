using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 単項演算を表すノードです
    /// </summary>
    //  例えば-xや!xを扱います
    public class UnaryExpressionNode : ExpressionNode
    {
        public TokenType Operator { get; }
        public ColoredToken OperatorToken { get; }
        public ExpressionNode Operand { get; }

        public UnaryExpressionNode(
            TokenType @operator,
            ColoredToken operatorToken,
            ExpressionNode operand
            )
        {
            Operator = @operator;
            OperatorToken = operatorToken;
            Operand = operand;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            rebuilder.ImportColoredToken(OperatorToken);
            Operand.ColoredTokenScan(rebuilder);
        }

        public override string ToPrettyString() =>
            Operator switch
            {
                TokenType.Minus => "-",
                _ => throw new System.Exception()
            }
            + Operand.ToPrettyString();
        public override void ASTScan(IInterpreter interepreter)
        {
            // 再帰呼び出し
            Operand.ASTScan(interepreter);
            // 自分自身
            interepreter.VisitUnaryExpression(this);
        }
    }
}
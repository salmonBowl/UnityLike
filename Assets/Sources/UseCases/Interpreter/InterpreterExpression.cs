using System;

using UnityLike.Entities.Compiler;
using UnityLike.Entities.Symbol;

namespace UnityLike.UseCases.Interpreter
{
    public partial class Interpreter : IVisitor
    {
        public Instance VisitBinaryExpression(BinaryExpressionNode node)
        {
            Instance value1 = node.LeftNode.ASTScan(this);
            Instance value2 = node.RightNode.ASTScan(this);

            try
            {
                return node.Operator switch
                {
                    TokenType.Plus => value1.Add(value2),
                    TokenType.Minus => value1.Subtract(value2),
                    TokenType.Multiply => value1.Multiply(value2),
                    TokenType.Divide => value1.Divide(value2),
                    _ => throw new InvalidOperatorException(node.OperatorToken)
                };
            }
            catch (InvalidOperatorException operatorException)
            {
                throw new InvalidOperatorException(operatorException.Message, node.OperatorToken);
            }
            catch (DivideByZeroException zeroException)
            {
                // ˆÓ–¡‰ðÍŽž‚É‚Í0Š„‚è‚ð–³Ž‹‚µ‚Ü‚·
                if (executionMode == ExecutionMode.SemanticAnalysisOnly)
                {
                    return value1;
                }

                throw new DivideByZeroExecuteException(zeroException.Message, node.OperatorToken);
            }
        }
        public Instance VisitVariable(VariableNode node)
        {
            return node.GetVariable(this).Value;
        }
        public Instance VisitIntLiteral(IntLiteralNode node)
        {
            return new IntInstance(node.Value);
        }
        public Instance VisitFloatLiteral(FloatLiteralNode node)
        {
            return new FloatInstance(node.Value);
        }
        public Instance VisitParenExpression(ParenNode node)
        {
            return node.Content.ASTScan(this);
        }
        public Instance VisitUnaryExpression(UnaryExpressionNode node)
        {
            Instance operand = node.Operand.ASTScan(this);

            try
            {
                return node.Operator switch
                {
                    TokenType.Minus => operand.Minus(),
                    TokenType.Not => operand.Denial(),
                    _ => throw new InvalidOperatorException(node.OperatorToken)
                };
            }
            catch (InvalidOperatorException e)
            {
                throw new InvalidOperatorException(e.Message, node.OperatorToken);
            }
        }
    }
}

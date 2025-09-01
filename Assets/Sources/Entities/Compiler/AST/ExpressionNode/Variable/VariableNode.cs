using UnityLike.Entities.Symbol;

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// •Ï”‚ğ•\Œ»‚·‚éƒm[ƒh‚Å‚·
    /// </summary>
    public abstract class VariableNode : ExpressionNode
    {
        public abstract Variable GetVariable(IVisitor interpreter);

        public override Instance ASTScan(IVisitor interpreter) => interpreter.VisitVariable(this);
    }
}
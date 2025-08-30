
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// Expressionの基底クラスです。
    /// Expression自身で階層構造をなし、最終的にはStatementNodeの構成要素となります。
    /// </summary>
    /*  
     *  Expression(leftparen, Expression(Expression(x), +, Expression(1)) rightparen)
     *  → (x+1) の文を表す
    */
    public abstract class ExpressionNode : Node
    {
    }
}

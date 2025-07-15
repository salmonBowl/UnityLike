
namespace UnityLike.Entities.Compiler
{
    /*
        基本的なノードの基底クラスです
            
            Expression(leftparen, Expression(Expression(x), +, Expression(1)) rightparen)
            これが (x+1) を表す
    */
    public abstract class ExpressionNode : Node
    {

    }
}
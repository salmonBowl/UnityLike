
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 一つの文を表現するノードの基底クラスです。現在はこれを構文木の根とし、List<StatementNode>の形でデータの受け渡しをしています。
    /// </summary>
    public abstract class StatementNode : Node
    {
        public abstract void ASTScan(IVisitor interpreter);
    }
}

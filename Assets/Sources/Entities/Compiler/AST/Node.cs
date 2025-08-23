
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 構文木を構成する全てのノードの基底クラスです。あるNodeが他のNodeを保持することで構文木という階層構造を成します。
    /// </summary>
    public abstract class Node
    {
        public abstract void LogThis();
        public abstract string ToPrettyString();
        public abstract void ASTScan(ISemanticAnalyzer semantic);
    }
}

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 構文木を構成する全てのノードの基底クラスです。あるNodeが他のNodeを保持することで構文木という階層構造を成します。
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// ノードが保持するトークンを順次rebuilderに送ります。これによりソースコードの復元ができるようになります。
        /// </summary>
        /// <param name="rebuilder"></param>
        public abstract void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder);
        public abstract string ToPrettyString();
        public abstract void ASTScan(IInterpreter interpreter);
    }
}
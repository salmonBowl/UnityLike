using System.Collections.Generic;

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// コンパイルを終えたデータを格納します。これは一度解析したデータを再利用する際に使用します。
    /// </summary>
    public class CompileData
    {
        /// <summary>
        /// トークン列です。元のソースコードを復元できるだけの情報を持っています。
        /// </summary>
        public List<ColoredToken> ColoredTokens { get; set; }

        /// <summary>
        /// 構文木です。これを使って色々な走査ができます。
        /// </summary>
        public List<StatementNode> AST { get; set; }
    }
}
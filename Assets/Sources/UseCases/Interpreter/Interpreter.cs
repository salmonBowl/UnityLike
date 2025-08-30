using System.Collections.Generic;

using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Interpreter
{
    /// <summary>
    /// 構文木を走査して実行するクラスです。構文木そのものと相互作用して解析を進めるという設計をとっています。
    /// </summary>
    public partial class Interpreter
    {
        /// <summary>
        /// 現在走査しているスコープを示します
        /// </summary>
        private SymbolTable currentScope;
        
        /// <summary>
        /// 意味解析を終えたIdentifierの型をスタックします。これにより型比較の仕組みを作ります。
        /// </summary>
        private readonly Stack<TypeBase> typeStack = new();

        private void Initialize()
        {
            currentScope = new SymbolTable(null);
        }
        private void Terminate()
        {
            // メモリ解法処理は少し重たいためcurrentScopeの明示的な破棄はしません
        }


        /// <summary>
        /// コードを実行します
        /// </summary>
        /// <param name="statements">実行するコードをstatementsの形式で渡します</param>
        public void ExecuteCode(List<StatementNode> statements)
        {
            Initialize();
            foreach (var statement in statements)
            {
                try
                {
                    statement.ASTScan(this);
                }
                catch (SemanticErrorException error)
                {
                    UnityEngine.Debug.Log($"エラーが発生しました : '{error.Message}'");
                }
            }
            Terminate();
        }
    }
}

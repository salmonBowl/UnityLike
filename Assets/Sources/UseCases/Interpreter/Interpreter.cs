using System;
using System.Collections.Generic;

using UnityLike.Entities.Compiler;
using UnityLike.Entities.Symbol;
using UnityLike.UseCases.Interpreter;

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
        private VariableTable currentScope;

        /// <summary>
        /// 実行モードを示します
        /// </summary>
        private ExecutionMode executionMode;

        /// <summary>
        /// コードを実行します
        /// </summary>
        /// <param name="statements">実行するコードをstatementsの形式で渡します</param>
        public void ExecuteCode(List<StatementNode> statements, List<Variable> initalMember, ExecutionMode mode)
        {
            Initialize(initalMember, mode);
            foreach (var statement in statements)
            {
                try
                {
                    statement.ASTScan(this);
                }
                catch (SemanticErrorException) { }
                catch (ExecuteException) { }
                catch (Exception e)
                {
                    UnityEngine.Debug.Log("開発上でエラーが発生しました : " + e);
                }
            }
            Terminate();
        }
        private void Initialize(List<Variable> initalMember, ExecutionMode mode)
        {
            currentScope = new VariableTable(null);
            foreach (var member in initalMember)
            {
                currentScope.AddMember(member);
            }

            executionMode = mode;
        }
        private void Terminate()
        {
            // メモリ解法処理は少し重たいためcurrentScopeの明示的な破棄はしません
        }
    }
}

using NUnit.Framework;
using System.Collections.Generic;

using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    /// <summary>
    /// 変数をdictionaryとして保持します
    /// 1つのインスタンスが保持するメンバー変数、またはその中の一つのスコープを表します
    /// </summary>
    public class VariableTable
    {
        private readonly Dictionary<string, Variable> variables = new();
        public VariableTable ParentScope { get; } // スコープが木構造を成すために必要な情報

        public VariableTable(VariableTable parentScope)
        {
            ParentScope = parentScope;
        }
        
        public void AddMember(params Variable[] members)
        {
            foreach (var m in members)
            {
                variables.Add(m.Name, m);
            }
        }

        public void AddUserVariable(Variable symbol, ColoredToken token)
        {
            // 再定義でないかをチェック
            if (variables.ContainsKey(symbol.Name))
            {
                throw new ReDefinitionException(symbol.Name, token);
            }

            variables.Add(symbol.Name, symbol);
        }

        /// <summary>
        /// 現在のスコープから親スコープへと遡って変数を名前で探します
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Symbol, null</returns>
        public Variable LookUpVariable(string name)
        {
            // 現在のスコープで見つかったならreturn
            if (variables.TryGetValue(name, out var mySymbol))
            {
                return mySymbol;
            }

            // 見つからなければだんだん上のスコープを検索
            if (ParentScope == null)
            {
                return null;
            }
            else// if (ParentScope != null)
            {
                return ParentScope.LookUpVariable(name);
            }
        }

        /// <summary>
        /// VariableTableが持つデータをリストとして取得します
        /// </summary>
        public List<Variable> GetVariableList()
        {
            var list = new List<Variable>();
            foreach (var m in variables)
            {
                list.Add(m.Value);
            }
            return list;
        }
    }
}

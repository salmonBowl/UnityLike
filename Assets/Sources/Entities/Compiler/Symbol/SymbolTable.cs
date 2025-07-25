
using System.Collections.Generic;

namespace UnityLike.Entities.Compiler
{
    /*
        SymbolTable
            シンボルをdictionaryとして保持します
            このクラスは一つのスコープを表します
     */
    public class SymbolTable
    {
        private readonly Dictionary<string, Symbol> symbols = new();
        public SymbolTable ParentScope { get; } // スコープが木構造を成すために必要な情報

        public SymbolTable(SymbolTable parentScope)
        {
            ParentScope = parentScope;
        }

        public void AddSymbol(Symbol symbol)
        {
            // 再定義でないかをチェック
            if (symbols.ContainsKey(symbol.Name))
            {
                throw new ReDefinitionException();
            }

            symbols.Add(symbol.Name, symbol);
        }

        // 現在のスコープから親スコープへと遡ってシンボルを名前で探します
        public Symbol LookUpSymbol(string name)
        {
            // 現在のスコープで見つかったならreturn
            if (symbols.TryGetValue(name, out var mySymbol))
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
                return ParentScope.LookUpSymbol(name);
            }
        }
    }
}

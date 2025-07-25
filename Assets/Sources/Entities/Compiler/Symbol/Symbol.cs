
namespace UnityLike.Entities.Compiler
{
    /*
        SymbolInfo
            各シンボルです
            変数やクラスなどの定義されたシンボルがこのクラスのインスタンスとして作られます
     */
    public class Symbol
    {
        public string Name { get; }
        public TypeBase Type { get; }
        public SymbolKind SymbolKind { get; }

        // 他の情報を後々追加予定

        public Symbol(
            string name,
            TypeBase type,
            SymbolKind symbolKind = SymbolKind.Variable
            )
        {
            Name = name;
            Type = type;
            SymbolKind = symbolKind;
        }
    }
}

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 無効な式を表すノードです。文法エラーを持つ式をこのノードで表現します。
    /// </summary>
    public class UnknownStatementNode : StatementNode
    {
        public Token[] Tokens { get; }
        
        public UnknownStatementNode(Token[] tokens)
        {
            Tokens = tokens;
        }
        public override string ToPrettyString()
        {
            string returnText = string.Empty;
            foreach(var token in Tokens)
            {
                returnText += token.ToPrettyString();
            }
            return returnText;
        }
        public override void ASTScan(ISemanticAnalyzer semantic)
        {
            // UnknownStatementで意味解析はなし
        }
    }
}
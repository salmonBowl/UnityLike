
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 無効な式を表すノードです。文法エラーを持つ式をこのノードで表現します。
    /// </summary>
    public class UnknownStatementNode : StatementNode
    {
        public Token[] Tokens { get; }
        public ColoredToken[] ColoredTokens { get; }
        
        public UnknownStatementNode(Token[] tokens, string errorMessage)
        {
            Tokens = tokens;
            ColoredTokens = new ColoredToken[Tokens.Length];
            for (int i = 0; i < Tokens.Length; i++)
            {
                ColoredTokens[i] = ASTFactory.TokenToColoredToken(Tokens[i]);
                ColoredTokens[i].HasError(errorMessage);
            }
        }

        public override void ExecuteCode() { }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            foreach(var cToken in ColoredTokens)
            {
                rebuilder.ImportColoredToken(cToken);
            }
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

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// ‘ã“ü®ƒm[ƒh
    /// int x = 0 ‚È‚Ç
    /// </summary>
    public class VariableDeclarationStatementNode : StatementNode
    {
        // ‹^—“I‚ÈÀ‘•‚ğ‚µ‚Ä‚¢‚Ü‚·
        // Œ»İ‚Í‚±‚Ì’†‚ÉTokenType.TypeStandard‚ğ“n‚µ‚Ü‚·
        public TokenType Type;
        public IdentifierNode Identifier { get; }
#nullable enable
        public ExpressionNode? InitalValue { get; }

        public VariableDeclarationStatementNode(
            TokenType type,
            IdentifierNode identifier,
            ExpressionNode initalValue
            )
            : this(type, identifier)
        {
            InitalValue = initalValue;
        }
        public VariableDeclarationStatementNode(TokenType type, IdentifierNode identifier)
        {
            Type = type;
            Identifier = identifier;
        }
    }
}
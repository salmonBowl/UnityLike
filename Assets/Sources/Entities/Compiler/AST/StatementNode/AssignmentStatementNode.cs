
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 変数へ代入する式を表すノードです
    /// </summary>
    /*
     *  表現する式 : x = 5;
     *  データ構造 : 代入式(型, 値)
     */
    public class AssignmentStatementNode : StatementNode
    {
        public IdentifierNode Identifier { get; }
        public ExpressionNode Value { get; }

        public ColoredToken EqualToken { get; }
        public ColoredToken CemicolonToken { get; }

        public AssignmentStatementNode(IdentifierNode identifier, ColoredToken equalToken,
            ExpressionNode value, ColoredToken cemicolonToken)
        {
            Identifier = identifier;
            Value = value;
            EqualToken = equalToken;
            CemicolonToken = cemicolonToken;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            Identifier.ColoredTokenScan(rebuilder);
            rebuilder.ImportColoredToken(EqualToken);
            Value.ColoredTokenScan(rebuilder);
            rebuilder.ImportColoredToken(CemicolonToken);
        }

        public override string ToPrettyString() =>
            $"{Identifier.ToPrettyString()} = {Value.ToPrettyString()};";

        public override void ASTScan(ISemanticAnalyzer semantic)
        {
            // StatementNodeでは自分自身の意味解析のみ行います
            semantic.VisitAssignmentStatement(this);
        }
    }
}
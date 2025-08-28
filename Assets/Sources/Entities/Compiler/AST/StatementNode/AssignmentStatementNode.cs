
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
        public ColoredToken SemicolonToken { get; }

        public AssignmentStatementNode(IdentifierNode identifier, ColoredToken equalToken,
            ExpressionNode value, ColoredToken semicolonToken)
        {
            Identifier = identifier;
            Value = value;
            EqualToken = equalToken;
            SemicolonToken = semicolonToken;
        }

        public override void ExecuteCode()
        {
            
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            Identifier.ColoredTokenScan(rebuilder);
            rebuilder.ImportColoredToken(EqualToken);
            Value.ColoredTokenScan(rebuilder);
            rebuilder.ImportColoredToken(SemicolonToken);
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
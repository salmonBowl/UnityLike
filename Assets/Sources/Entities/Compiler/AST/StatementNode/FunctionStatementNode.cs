
namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 関数を実行する一文を表すノードです
    /// </summary>
    public class FunctionStatementNode : StatementNode
    {
        public MemberFunctionNode Function { get; }
        public ColoredToken SemicolonToken { get; }

        public FunctionStatementNode(MemberFunctionNode function, ColoredToken semicolon)
        {
            Function = function;
            SemicolonToken = semicolon;
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            Function.ColoredTokenScan(rebuilder);
            rebuilder.ImportColoredToken(SemicolonToken);
        }

        public override string ToPrettyString() => Function.ToPrettyString() + ";";

        public override void ASTScan(IVisitor interpreter)
        {
            interpreter.ExecuteFunctionStatement(this);
        }
    }
}

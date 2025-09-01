#nullable enable

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// 変数宣言の式を表すノードです
    /// </summary>
    /*
     *  表現する式 : int x = 0;
     *  データ構造 : 変数宣言式(int x ; , 代入式(x = 0 ;))
     *  実際の形式 : VariableDeclarationStatementNode(TypeNode, DeclaratedIdentifierNode, AssignmentStatementNode);
     */
    public class VariableDeclarationStatementNode : StatementNode
    {
        // 疑似的な実装をしています
        // 現在はこの中にTokenType.TypeStandardを渡します
        public TypeNode Type;
        public DeclaratedIdentifierNode DeclaratedIdentifier { get; }
        public AssignmentStatementNode? InitalAssignment { get; } = null;

        public ColoredToken SemicolonToken { get; }

        public VariableDeclarationStatementNode(TypeNode type, IdentifierNode identifier, ColoredToken semicolonToken)
        {
            Type = type;
            DeclaratedIdentifier = new DeclaratedIdentifierNode(identifier);
            SemicolonToken = semicolonToken;
        }
        public VariableDeclarationStatementNode(TypeNode type, IdentifierNode identifier,
            ColoredToken equalToken, ExpressionNode initalValue, ColoredToken semicolonToken
            ) : this(type, identifier, semicolonToken)
        {
            InitalAssignment = new AssignmentStatementNode(identifier, equalToken, initalValue, semicolonToken);
        }

        public override void ColoredTokenScan(ISourceCodeRebuildFromColoredToken rebuilder)
        {
            Type.ColoredTokenScan(rebuilder);
            if (InitalAssignment == null)
            {
                DeclaratedIdentifier.ColoredTokenScan(rebuilder);
                rebuilder.ImportColoredToken(SemicolonToken);
            }
            else
            {
                InitalAssignment.ColoredTokenScan(rebuilder);
            }

        }

        public override string ToPrettyString() =>
            Type.ToPrettyString() +
            ((InitalAssignment == null) ?
            $" {DeclaratedIdentifier};" :
            InitalAssignment.ToPrettyString());
        public override void ASTScan(IVisitor interpreter)
        {
            interpreter.ExecuteVariableDeclarationStatement(this);
        }
    }
}

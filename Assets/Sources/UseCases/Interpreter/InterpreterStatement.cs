
using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Interpreter
{
    public partial class Interpreter : IInterpreter
    {
        public void ExecuteVariableDeclarationStatement(VariableDeclarationStatementNode node)
        {
            // 各語句の意味解析を先に行う

            node.Type.ASTScan(this);
            node.DeclaratedIdentifier.ASTScan(this);

            object value = null;

            // デフォルト値の決定（例: intは0、Vector3はVector3.zero）
            // この部分はTypeConstantsなどから取得するロジックが必要
            value = GetDefaultValue(node.Type.Name);

            // 変数をシンボルテーブルに登録
            currentScope.AddSymbol(node.DeclaratedIdentifier.Name, node.Type, value);

            // 初期化があればInitalAssignmentStatementの走査に移る
            node.InitalAssignment?.ASTScan(this);
        }

        public void ExecuteAssignmentStatement(AssignmentStatementNode node)
        {
            // 各語句の意味解析を先に行う

            node.Identifier.ASTScan(this);
            node.Value.ASTScan(this);

            // 文全体の意味解析

            // 右辺の式を評価して値を取得
            object value = EvaluateExpression(node.Value);

            // シンボルテーブルで変数を検索し、値を更新
            Symbol symbol = currentScope.LookUpSymbol(node.Identifier.Name);
            if (symbol == null)
            {
                throw new IdentifierNotFoundException(node.Identifier.Name);
            }
            symbol.Value = value; // シンボルに値を持たせる
        }
    }
}

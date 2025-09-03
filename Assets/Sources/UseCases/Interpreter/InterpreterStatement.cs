using UnityLike.Entities.Compiler;
using UnityLike.Entities.Symbol;

namespace UnityLike.UseCases.Interpreter
{
    public partial class Interpreter : IVisitor
    {
        public void ExecuteVariableDeclarationStatement(VariableDeclarationStatementNode node)
        {
            // 変数を生成
            string variableName = node.DeclaratedIdentifier.Name;
            Class variableType = TypeRegistry.TypeOf(node.Type.Name, node.Type.NameToken);
            Variable variable = new(variableName, variableType)
            {
                // 変数の初期値
                Value = variableType.GetInitalInstance()
            };

            // 変数の追加
            currentScope.AddUserVariable(variable, node.DeclaratedIdentifier.IdentifierToken);

            // 初期化式があればInitalAssignmentStatementの走査に移る
            node.InitalAssignment?.ASTScan(this);
        }

        public void ExecuteAssignmentStatement(AssignmentStatementNode node)
        {
            // 各語句の意味解析を先に行う
            node.Variable.ASTScan(this);
            node.Value.ASTScan(this);

            // 左辺の値を取得
            Variable variable = node.Variable.GetVariable(this);

            // 右辺の値を取得
            Instance value = node.Value.ASTScan(this);

            // 変数の値を更新
            variable.AssignmentValue(value, node.EqualToken);
        }
    }
}

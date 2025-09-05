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

            // 意味解析時に代入は行いません
            if (executionMode == ExecutionMode.SemanticAnalysisOnly)
                return;

            // 左辺の値を取得
            Variable variable = node.Variable.GetVariable(this);

            // 右辺の値を取得
            Instance value = node.Value.ASTScan(this);

            // 変数の値を更新
            variable.AssignmentValue(value, node.EqualToken);
        }

        public void ExecuteIfStatement(IfStatementNode node)
        {
            Instance conditionValue = node.Condition.ASTScan(this);

            if (conditionValue is not BoolInstance boolValue)
            {
                throw new ConditionNotBoolException(node.RightParenToken);
            }

            bool condition = boolValue.AsBool();
            bool isBoth = executionMode == ExecutionMode.SemanticAnalysisOnly;

            if (condition || isBoth)
            {
                node.Then.ASTScan(this);
            }
            if (!condition || isBoth)
            {
                node.Else?.ASTScan(this);
            }
        }
        public void ExecuteWhileStatement(WhileStatementNode node)
        {
            Instance conditionValue = node.Condition.ASTScan(this);

            if (conditionValue is not BoolInstance)
            {
                throw new ConditionNotBoolException(node.RightParenToken);
            }

            bool atOnce = executionMode == ExecutionMode.SemanticAnalysisOnly;

            if (atOnce)
            {
                node.Statement.ASTScan(this);
            }
            else
            {
                int loopCount = 0;
                const int maxIterations = 10000; // 安全のためのループ上限回数
                
                while (true)
                {
                    bool condition = ((BoolInstance)node.Condition.ASTScan(this)).AsBool();
                    if (!condition)
                        break;

                    node.Statement.ASTScan(this);

                    loopCount++;
                    if (maxIterations < loopCount)
                    {
                        throw new InfiniteLoopException(node.WhileToken);
                    }
                }
            }
        }

        public void ExecuteScope(ScopeNode scope)
        {
            VariableTable parentScope = currentScope;
            VariableTable newScope = new(currentScope);

            currentScope = newScope;

            foreach (var statement in scope.Statements)
            {
                statement.ASTScan(this);
            }

            currentScope = parentScope;
        }
    }
}

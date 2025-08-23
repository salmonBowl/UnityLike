using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    partial class SemanticAnalyzer : ISemanticAnalyzer
    {
        public void VisitVariableDeclarationStatement(VariableDeclarationStatementNode node)
        {
            // 各語句の意味解析を先に行う

            node.Type.ASTScan(this);
            node.DeclaratedIdentifier.ASTScan(this);

            // 文全体の意味解析

            string typeName = node.Type.Name;
            string identifierName = node.DeclaratedIdentifier.Name;
            TypeBase type = TypeConstants.definedTypes[typeName];

            Symbol newSymbol = new(identifierName, type);
            currentScope.AddSymbol(newSymbol);

            // 初期化があればInitalAssignmentStatementの走査に移る
            node.InitalAssignment?.ASTScan(this);
        }

        public void VisitAssignmentStatement(AssignmentStatementNode node)
        {
            // 各語句の意味解析を先に行う

            node.Identifier.ASTScan(this);
            node.Value.ASTScan(this);

            // 文全体の意味解析

            
        }
    }
}

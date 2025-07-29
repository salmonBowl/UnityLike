using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    partial class SemanticAnalyzer : ISemanticAnalyzer
    {
        public void VisitVariableDeclarationStatement(VariableDeclarationStatementNode node)
        {
            string typeName = node.Type.Name;
            string identifierName = node.Identifier.Name;

            TypeConstants.Types.TryGetValue(typeName, out TypeBase type);

            if (currentScope.LookUpSymbol(identifierName) != null) // •Ï”‚ªŠù‚É’è‹`‚³‚ê‚Ä‚¢‚½ê‡
            {
                throw new ReDefinitionException(identifierName);
            }

            Symbol newSymbol = new(identifierName, type);
            currentScope.AddSymbol(newSymbol);
        }

        public void VisitAssignmentStatement(AssignmentStatementNode node)
        {
            // –¢À‘•
        }
    }
}

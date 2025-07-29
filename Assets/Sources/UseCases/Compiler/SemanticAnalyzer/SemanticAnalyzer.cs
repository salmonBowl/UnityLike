using System.Collections.Generic;

using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    public partial class SemanticAnalyzer : ISemanticAnalyzer
    {
        private SymbolTable currentScope;
        private List<SemanticErrorException> errors;
        
        public SemanticAnalyzer()
        {
            currentScope = new(null);
            errors = new();
        }

        public void Analyze(List<StatementNode> statements)
        {
            foreach (var statement in statements)
            {
                try
                {
                    statement.ASTScan(this);
                }
                catch (SemanticErrorException error)
                {
                    errors.Add(error);
                }
            }
        }
    }
}
